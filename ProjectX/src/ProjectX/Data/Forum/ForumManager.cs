using Microsoft.EntityFrameworkCore;
using ProjectX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Data.Forum
{
    public class ForumManager
    {
        public ForumManager()
        {
            Forums = new List<Forum>();
        }
        public void MockLoad()
        {
            Random rnd = new Random();

            var user1 = new ApplicationUser();
            user1.UserName = "Kiss Péter";
            var user2 = new ApplicationUser();
            user2.UserName = "John Doe";
            var user3 = new ApplicationUser();
            user3.UserName = "Barack Obama";

            var dpForum = new Forum("Digital Painting");
            var dpTopic = new Topic("How to draw your dragon?");
                dpTopic.Comments.Add(new Comment(user1, "Anyád", dpTopic, DateTime.Now.AddDays(rnd.Next(100))));
                dpTopic.Comments.Add(new Comment(user1, "Comment", dpTopic, DateTime.Now.AddDays(rnd.Next(100))));
                dpTopic.Comments.Add(new Comment(user1, "Feget", dpTopic, DateTime.Now.AddDays(rnd.Next(100))));
            var dpTopic2 = new Topic("Drawing a penis has never been easier!");
                dpTopic2.Comments.Add(new Comment(user1, "Pisti jó vagy!", dpTopic, DateTime.Now.AddDays(rnd.Next(100))));
                dpTopic2.Comments.Add(new Comment(user1, "What the fuck!", dpTopic, DateTime.Now.AddDays(rnd.Next(100))));
                dpTopic2.Comments.Add(new Comment(user1, "Lolz", dpTopic, DateTime.Now.AddDays(rnd.Next(100))));
            var dpTopic3 = new Topic("Drawing a stool.");
                dpTopic3.Comments.Add(new Comment(user1, "Imba", dpTopic, DateTime.Now.AddDays(rnd.Next(100))));
                dpTopic3.Comments.Add(new Comment(user1, "Miafaszez?", dpTopic, DateTime.Now.AddDays(rnd.Next(100))));
                dpTopic3.Comments.Add(new Comment(user1, "Haha", dpTopic, DateTime.Now.AddDays(rnd.Next(100))));
            var dpTopic4 = new Topic("How to install photoshop?");
                dpTopic4.Comments.Add(new Comment(user1, "Hogy mondod?", dpTopic, DateTime.Now.AddDays(rnd.Next(100))));
                dpTopic4.Comments.Add(new Comment(user1, "Csicska!", dpTopic, DateTime.Now.AddDays(rnd.Next(100))));
                dpTopic4.Comments.Add(new Comment(user1, "Lollercoaster", dpTopic, DateTime.Now.AddDays(rnd.Next(100))));
            var dpTopic5 = new Topic("What to draw?");
                dpTopic5.Comments.Add(new Comment(user1, "Heppednorka", dpTopic, DateTime.Now.AddDays(rnd.Next(100))));
                dpTopic5.Comments.Add(new Comment(user1, "Pesztika", dpTopic, DateTime.Now.AddDays(rnd.Next(100))));
                dpTopic5.Comments.Add(new Comment(user1, "Pasztaloka", dpTopic, DateTime.Now.AddDays(rnd.Next(100))));

            dpForum.Topics.Add(dpTopic);
            dpForum.Topics.Add(dpTopic2);
            dpForum.Topics.Add(dpTopic3);
            dpForum.Topics.Add(dpTopic4);
            dpForum.Topics.Add(dpTopic5);
            Forums.Add(dpForum);
        }
        public bool Load()
        {
            /*
            using (var context = new ApplicationDbContext())
            {
                var data = from b in context.Users where b.Email == "asd" select b;
            }
            */
            MockLoad();

            return true;
        }
        public List<Forum> Forums { get; set; }

        public Forum GetForumByTitle(string title)
        {
            if (title == null) throw new ArgumentNullException();

            return Forums.Where(forum => forum.Title == title).Single();
        }

        public Topic GetTopicByTitle(string title, Forum parentForum)
        {
            if (title == null || parentForum == null) throw new ArgumentNullException();

            return parentForum.Topics.Where(topic => topic.Title == title).Single();
        }

        public Comment GetLastComment(Topic topic)
        {
            if (topic == null) throw new ArgumentNullException();

            return topic.Comments.OrderBy(comment => comment.CommentDate).First();
        }

        public List<Topic> GetTopFiveTopics(Forum parentForum)
        {
            if (parentForum == null) throw new ArgumentNullException();

            return parentForum.Topics.OrderBy(topic => topic.Comments.Count).Take(5).ToList();
        }
    }
}
