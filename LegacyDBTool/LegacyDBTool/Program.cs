using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LegacyDBTool
{
    class Program
    {
        const string awsDBPath = @"C:\Users\Administrator\Desktop\LegacyDB\AWS_DB";
        const string userFolderName = "flhsz";
        const string imageFolderName = "csillagok";

        static void Main(string[] args)
        {
            var users = ParseUsers(awsDBPath + "\\" + userFolderName);
            users = ExpandDataWithImageStars(users, awsDBPath + "\\" + imageFolderName);
            ExportDataToXml(users, "Users.xml");
            ExportData(users, "Export.txt");

            foreach (var user in users) {
                Console.WriteLine("----");
                Console.WriteLine(user.ToString());
            }

            Console.ReadKey();
        }

        private static List<User> ExpandDataWithImageStars(List<User> data, string imageDirectory)
        {
            var files = Directory.EnumerateFiles(imageDirectory);
            var filenames = files.ToList().Select(x => (Path.GetFileNameWithoutExtension(x)));

            foreach (var user in data)
            {
                if (user.images == null) continue;

                foreach (var image in user.images)
                {
                    foreach(var file in files)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(file);
                        if (image.id == fileName)
                        {
                            var lines = File.ReadAllLines(file);

                            try
                            {
                                int.TryParse(lines[0], out image.stars);
                            }
                            catch
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return data;
        }

        public static void ExportData(List<User> data, string fileName)
        {
                var file = File.CreateText(fileName);
            foreach(var u in data)
                file.WriteLine(u.ToString2());
            file.Close();
        }

        public static void ExportDataToXml(List<User> data, string fileName)
        {
            var xs = new XmlSerializer(typeof(List<User>));
            var encoding = Encoding.GetEncoding("UTF-8");
            var sw = new StringWriterWithEncoding(encoding);

            using (XmlWriter writer = XmlWriter.Create(sw, new XmlWriterSettings() { Encoding = Encoding.UTF8 }))
            {
                xs.Serialize(writer, data);
                var xml = sw.ToString();

                var file = File.CreateText(fileName);
                file.Write(xml);
                file.Close();
            }
        }

        public static List<User> ParseUsers(string usersDirectory)
        {
            var dirs = Directory.EnumerateDirectories(usersDirectory);

            var users = new List<User>();

            foreach (var dir in dirs)
            {
                var user = new User();
                user.id = dir.Substring(dir.LastIndexOf("\\") + 1);

                var files = Directory.EnumerateFiles(dir);

                foreach (var file in files)
                {

                    var filename = Path.GetFileNameWithoutExtension(file);
                    var lines = File.ReadAllLines(file);

                    if (lines == null)
                    {
                        lines = new string[] { string.Empty };
                    }
                    else if (lines.ToList().Count == 0)
                    {
                        lines = new string[] { string.Empty };
                    }

                    switch (filename)
                    {
                        case UserFileNames.username:
                            user.username = lines[0];
                            break;
                        case UserFileNames.password:
                            user.password = lines[0];
                            break;
                        case UserFileNames.registrationDate:
                            //Format: 2016.06.22. 20:15
                            var registrationPattern = "yyyy.MM.dd. HH:mm";
                            user.registrationDate = DateTime.ParseExact(lines[0], registrationPattern, null);
                            break;
                        case UserFileNames.name:
                            user.name = lines[0];
                            break;
                        case UserFileNames.address:
                            user.address = lines[0];
                            break;
                        case UserFileNames.email:
                            user.email = lines[0];
                            break;
                        case UserFileNames.phoneNumber:
                            user.phoneNumber = lines[0];
                            break;
                        case UserFileNames.premium:
                            if (lines[0] == "0") break;
                            var premiumPattern = "yyyy. MM. dd. ";
                            user.premium = DateTime.ParseExact(lines[0], premiumPattern, null);
                            break;
                        case UserFileNames.newsletter:
                            user.newsletter = lines[0] == "1";
                            break;
                        case UserFileNames.images:
                            if (lines == null || (lines.Length == 1 && lines[0] == string.Empty))
                            {
                                user.images = null;
                                break;
                            }

                            foreach (var line in lines)
                            {
                                var image = new Image();
                                image.id = line;
                                user.images.Add(image);
                            }

                            break;
                        case UserFileNames.description:
                            user.description = lines[0];
                            break;
                        case UserFileNames.cover:
                            user.cover = lines[0];
                            break;
                        case UserFileNames.avatar:
                            user.avatar = lines[0];
                            break;
                        case UserFileNames.billingName:
                            user.billingName = lines[0];
                            break;
                        case UserFileNames.billingAddress:
                            user.billingAddress = lines[0];
                            break;
                        case UserFileNames.bankAccountNum:
                            user.bankAccountNum = lines[0];
                            break;
                        case UserFileNames.balance:
                            int.TryParse(lines[0], out user.balance);
                            break;
                        case UserFileNames.facebookProfile:
                            user.facebookProfile = lines[0];
                            break;
                        case UserFileNames.instagramProfile:
                            user.instagramProfile = lines[0];
                            break;
                        case UserFileNames.website:
                            user.website = lines[0];
                            break;

                        //following is not stored by id
                        //must check code to see how it is managed

                        /*case UserFileNames.following:
                            var temp = lines.ToList();
                            temp.RemoveAll(x => (x == string.Empty));
                            user.following = temp;
                            break;*/
                        default:
                            break;
                    }
                }
                users.Add(user);
                Console.Write("\rParsed " + users.Count + " out of " + dirs.ToList().Count + ".");
            }

            return users;
        }
    }

    public sealed class StringWriterWithEncoding : StringWriter
    {
        private readonly Encoding encoding;

        public StringWriterWithEncoding(Encoding encoding)
        {
            this.encoding = encoding;
        }

        public override Encoding Encoding
        {
            get { return encoding; }
        }
    }
}
