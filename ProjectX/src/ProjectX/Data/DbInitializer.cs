using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using ProjectX.Models;

namespace ProjectX.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            

            XDocument usersXml = XDocument.Load(".\\Data\\LegacyDB\\Users.xml");
            var users = from User in usersXml.Descendants("User")
                        select User;

            /*var users = new User[]
            {
            new User{Username  = "awking", Password  = "c3a1161d31ccacd1cc3844514e295357", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "Zsibrita András", Address  = "", Email  = "awking@freemail.hu", PhoneNumber  = "06 30 291 16 62", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "", Cover  = "borito_img-0387-jpg.exact1049x699.jpg", Avatar  = "vasember.png", BillingName  = "", BillingAddress  = "5662 Csanádapáca Alkotmány út 13.", BankAccountNum  = "", Balance  = 0, FacebookProfile  = "", InstagramProfile  = "", Website  = "awking.hu"},
            new User{Username  = "lorantart", Password  = "b87c58c531a2af8c4bbacc37412b00fe", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "Lorant Toth", Address  = "Bag p u 17", Email  = "loci922@gmail.com", PhoneNumber  = "+36-30-427-4274", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "Média design hallgató a MET-en. :)", Cover  = "borito_lost-shores-resized.jpg", Avatar  = "untitled-1.jpg", BillingName  = "lorant", BillingAddress  = "Bag, p u 17", BankAccountNum  = "1", Balance  = 0, FacebookProfile  = "www.facebook.com/lorant.toth", InstagramProfile  = "instagram.com/lorantart", Website  = "www.lorantart.com"},
            new User{Username  = "Zsubio", Password  = "c00aa80186a9a6bbd557313340aab355", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "Tóth Zsolt", Address  = " ", Email  = "zsubio@jarart.hu", PhoneNumber  = "0630-378-1057", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "Azt mondják, hogy a műszaki emberek vonzódnak a művészetekhez, és ez szerintem is így van, a saját példám is ezt igazolja. Mivel nagyra értékelem azokat az embereket, akik különleges alkotások létrehozására képesek, azon vagyok, hogy az alkotásaikon keresztül legalább egy kicsit tanuljak tőlük.", Cover  = "borito_hatter-100.jpg", Avatar  = "profilkep-100.jpg", BillingName  = "Tóth Zsolt", BillingAddress  = "2191 Bag, Peres u. 17.", BankAccountNum  = "11773683-91039266", Balance  = 0, FacebookProfile  = "www.facebook.com/jarart-fotó-hozd-a-nagyit-is-505001766272056/?ref=hl", InstagramProfile  = "", Website  = ""},
            new User{Username  = "Fábián Fatime Alíz", Password  = "0811cfdb5c97a5a6347866c287c8f78e", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "Fábián Fatime Alíz", Address  = "6326 Harta, Kossuth L. u. 28.", Email  = "fabian.fatime@citromail.hu", PhoneNumber  = "06703872710", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "", Cover  = "", Avatar  = "", BillingName  = "", BillingAddress  = "6326 Harta, kossuth L. u. 28. ", BankAccountNum  = "", Balance  = 0, FacebookProfile  = "", InstagramProfile  = "", Website  = ""},
            new User{Username  = "Podhradszky Marietta", Password  = "69f8bea4bef27203529ec7ef92f5c8ee", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "Podhradszky Marietta", Address  = "1182 Kétujfalú u. 58,I/40", Email  = "p_marietta@freemail.hu", PhoneNumber  = "36305326268", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "", Cover  = "", Avatar  = "", BillingName  = "", BillingAddress  = "1182 Kétujfalú u.58,I/40", BankAccountNum  = "", Balance  = 0, FacebookProfile  = "", InstagramProfile  = "", Website  = ""},
            new User{Username  = "saci", Password  = "5ace4de943cc57bee2a1b535d51324c0", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "Saci", Address  = "", Email  = "dunaisarolta@index.hu", PhoneNumber  = "30-9454232", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "", Cover  = "", Avatar  = "", BillingName  = "", BillingAddress  = "1028.Bp.Szilágyi 14a", BankAccountNum  = "", Balance  = 0, FacebookProfile  = "", InstagramProfile  = "", Website  = ""},
            new User{Username  = "dr. Kovács nikolett", Password  = "9b38d2e4dc0415887fe2f17ec94baa4b", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "dr. Kovács nikolett", Address  = "", Email  = "drkovacsnikolett@gmail.com", PhoneNumber  = "06304181435", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "", Cover  = "", Avatar  = "", BillingName  = "", BillingAddress  = "1118 budapest, haraszt u. 20. i/4.", BankAccountNum  = "", Balance  = 0, FacebookProfile  = "", InstagramProfile  = "", Website  = ""},
            new User{Username  = "Hekk Noémi", Password  = "c3c83706c1ecdcb71313e5ca478e17b1", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "Hekk Noémi", Address  = "1081 Budapest, II.János Pál pápa tér 12.2/16", Email  = "hneomi@freemail.hu", PhoneNumber  = "70/7790489", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "", Cover  = "", Avatar  = "", BillingName  = "", BillingAddress  = "1081 Budapest, II.János Pál pápa tér 12.2/16", BankAccountNum  = "", Balance  = 0, FacebookProfile  = "", InstagramProfile  = "", Website  = ""},
            new User{Username  = "Floch Ildikó", Password  = "037dd69704c22b8fe4fb0e9c95fd9fcb", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "Floch Ildikó", Address  = "", Email  = "ildiko.floch@gmail.com", PhoneNumber  = "20/3979-972", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "", Cover  = "", Avatar  = "", BillingName  = "", BillingAddress  = "2600 Vác, Köztársaság út 35.", BankAccountNum  = "", Balance  = 0, FacebookProfile  = "", InstagramProfile  = "", Website  = ""},
            new User{Username  = "Zombori Györgyi", Password  = "9664940415646552c96c505395d9fe22", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "Zombori Györgyi", Address  = "1112 Bp. Zólyomi köz 10-12.", Email  = "zombori37@gmail.com", PhoneNumber  = "70/335262", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "Még csak néhány év telt el azóta, hogy az elmetágító segítségével elkezdtem a különféle festési technikákkal ismerkedni. Gyakorlatilag a nulláról kezdtem. Erzsi és Zsolt segítségével gazdagabb lettem, sok élménnyel, a jó társasággal, a jó hangulatú közös  alkotás örömével. Sokan nem értékelik az akvarellt, nekem mégis ez a kedvencem. Szeretem a légies, fátyolos színeit. Szeretem, hogy a papír és a víz időnként önállósítja magát. Szívesen festek akrillal, és mostanában ismerkedem az olajfestéssel is. ", Cover  = "borito_toscana.jpg", Avatar  = "zsolt-fotoja_2.jpg", BillingName  = "", BillingAddress  = "1112 Bp. Zólyomi köz 10-12.", BankAccountNum  = "", Balance  = 0, FacebookProfile  = "", InstagramProfile  = "", Website  = ""},
            new User{Username  = "Bálint zsuzsanna", Password  = "5bd7a8ba4c3e10f1be5643bbd10d47da", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "Bálint zsuzsanna", Address  = "", Email  = "zsuzska700722@freemail.hu", PhoneNumber  = "06308553831", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "", Cover  = "", Avatar  = "", BillingName  = "", BillingAddress  = "2400 dunaújváros, szórád márton út 38. 2/1", BankAccountNum  = "", Balance  = 0, FacebookProfile  = "", InstagramProfile  = "", Website  = ""},
            new User{Username  = "Gratzer-Sövényházy Edit", Password  = "b5de4dfaeee4738c50bb5e67d794164a", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "Gratzer-Sövényházy Edit", Address  = "", Email  = "seditke@gmail.com", PhoneNumber  = "+36703353456", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "", Cover  = "borito_dorci----kicsi-jav2.jpg", Avatar  = "eda-portre.jpg", BillingName  = "", BillingAddress  = "6725 Szeged, Ybl Miklós utca 6.", BankAccountNum  = "", Balance  = 0, FacebookProfile  = "", InstagramProfile  = "", Website  = ""},
            new User{Username  = "Bartók Erzsébet", Password  = "c00aa80186a9a6bbd557313340aab355", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "Bartók Erzsébet", Address  = "21*1 Bafhh", Email  = "bartokerzsebet@gmail.com", PhoneNumber  = "302662626262", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "Számomra az alkotás egy tanulási folyamat, amivel az a célom, hogy miután én már megtanultam, azt minél több embernek megtanítsam. Számomra nem az az igazi siker, amikor valamelyik képem tetszik valakiknek, hanem amikor az általam elindított úton mások egyre szebb alkotásokat hoznak létre és látom az arcukon az alkotás semmihez sem hasonlító örömét. Az én igazi alkotásom: a tanítás.", Cover  = "borito_zso-profil.jpg", Avatar  = "bkep-250.jpg", BillingName  = "anonímus", BillingAddress  = "2191 Bag Peres u. 17.", BankAccountNum  = "117", Balance  = 0, FacebookProfile  = "www.facebook.com/erzsebet.bartok.3?fref=ts", InstagramProfile  = "", Website  = ""},
            new User{Username  = "Elmetágító", Password  = "c00aa80186a9a6bbd557313340aab355", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "Elmetágító", Address  = "", Email  = "elmetagito@elmetagito.hu", PhoneNumber  = "302662626262", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "", Cover  = "", Avatar  = "emblema-100.jpg", BillingName  = "", BillingAddress  = "1139 Budapest Forgách u. 19.", BankAccountNum  = "", Balance  = 0, FacebookProfile  = "", InstagramProfile  = "", Website  = ""},
            new User{Username  = "Bánky Csaba", Password  = "b2bbdb51a0d9a9f30cd43edfe970afe0", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "Bánky Csaba", Address  = "", Email  = "farkasbanky@t-online.hu", PhoneNumber  = "304032964", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "", Cover  = "", Avatar  = "010_2014.jpg", BillingName  = "", BillingAddress  = "1137 Bp. Pozsonyi út 10", BankAccountNum  = "", Balance  = 0, FacebookProfile  = "", InstagramProfile  = "", Website  = ""},
            new User{Username  = "OrencsákJudit", Password  = "32c339663377be5c796673de97b2cbca", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "OrencsákJudit", Address  = "1222 Budapest", Email  = "orencsak@gmail.com", PhoneNumber  = "303231514", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "", Cover  = "", Avatar  = "", BillingName  = "", BillingAddress  = "1222 Budapest", BankAccountNum  = "", Balance  = 0, FacebookProfile  = "", InstagramProfile  = "", Website  = ""},
            new User{Username  = "Koltay Zsuzsa", Password  = "a9e655d852e269d9f8ffd44460c3b6d0", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "Koltay Zsuzsa", Address  = "", Email  = "koltaynezsuzsa@invitel.hu", PhoneNumber  = "20-3351871", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "", Cover  = "", Avatar  = "dscf3586.jpg", BillingName  = "", BillingAddress  = "2100 Gödöllő,Mikszáth.K.u.28.", BankAccountNum  = "", Balance  = 0, FacebookProfile  = "", InstagramProfile  = "", Website  = ""},
            new User{Username  = "Matisz Istvánné/ Ica", Password  = "b19eee24413772299e13f2908a32101c", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "Matisz Istvánné/ Ica", Address  = "1139 Budapest, Üteg u. 31.", Email  = "ica.matisz@gmail.com", PhoneNumber  = "06-20-916-1874", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "Az iskoláim elvégzése után már nem igen volt alkalmam kedvenc hobbim (festés, rajzolás)gyakorlására. Mindig mondtam, no majd ha nyugdíjas leszek lesz rá időm. Így is történt, amint tehettem elővettem a ceruzát, ecsetet és próbáltam a rég elfojtott szenvedélyemnek teret engedni. ", Cover  = "borito_145csorgedezo-patak2.jpg", Avatar  = "matisz-ica-.jpg", BillingName  = "", BillingAddress  = "1139 Budapest,Üteg u. 31.", BankAccountNum  = "", Balance  = 0, FacebookProfile  = "", InstagramProfile  = "", Website  = ""},
            new User{Username  = "VadSiraly", Password  = "5d305903e4a0b73eb9f72e2497b138b6", RegistrationDate = DateTime.Parse("2014-09-01"), Name  = "VadSiraly", Address  = "", Email  = "nodhtirl@gmail.com", PhoneNumber  = "0036303660919", Premium = DateTime.Parse("2014-09-01"), Newsletter  = false, Description  = "", Cover  = "", Avatar  = "", BillingName  = "", BillingAddress  = "2191, Bag Peres u. 17", BankAccountNum  = "", Balance  = 0, FacebookProfile  = "", InstagramProfile  = "", Website  = ""}
            };*/

            /*
            <id>20150902100430c2710e359cbc5ba58f6d6b8d78a5bb64</id>
		    <username>awking</username>
		    <password>c3a1161d31ccacd1cc3844514e295357</password>
		    <registrationDate>2015-09-02T10:04:00</registrationDate>
		    <name>Zsibrita András</name>
		    <address />
		    <email>awking@freemail.hu</email>
		    <phoneNumber>06 30 291 16 62</phoneNumber>
		    <premium>2016-03-29T00:00:00</premium>
		    <newsletter>false</newsletter>
		    <description />
		    <cover>borito_img-0387-jpg.exact1049x699.jpg</cover>
		    <avatar>vasember.png</avatar>
		    <billingName />
		    <billingAddress>5662 Csanádapáca Alkotmány út 13.</billingAddress>
		    <bankAccountNum />
		    <balance>0</balance>
		    <facebookProfile />
		    <instagramProfile />
		    <website>awking.hu</website>
            */
            foreach (var u in users)
            {
                ApplicationUser user = null;
                try
                {
                    user = new ApplicationUser
                    {
                        UserName = u.Element("username").Value,
                        LegacyPassword = u.Element("password").Value,
                        RegistrationDate = DateTime.Parse(u.Element("registrationDate").Value),
                        Name = u.Element("name").Value,
                        Address = u.Element("address").Value,
                        Email = u.Element("email").Value,
                        PhoneNumber = u.Element("phoneNumber").Value,
                        Premium = DateTime.Parse(u.Element("premium").Value),
                        Newsletter = bool.Parse(u.Element("newsletter").Value),
                        Description = u.Element("description").Value,
                        Cover = u.Element("cover").Value,
                        Avatar = u.Element("avatar").Value,
                        BillingName = u.Element("billingName").Value,
                        BillingAddress = u.Element("billingAddress").Value,
                        BankAccountNum = u.Element("bankAccountNum").Value,
                        Balance = int.Parse(u.Element("balance").Value),
                        FacebookProfile = u.Element("facebookProfile").Value,
                        InstagramProfile = u.Element("instagramProfile").Value,
                        Website = u.Element("website").Value
                    };
                }
                catch
                {
                    //couldnt add user
                }

                if (user != null)
                    context.Users.Add(user);

            }
            context.SaveChanges();
        }
    }
}
