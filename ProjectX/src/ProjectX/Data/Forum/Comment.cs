using ProjectX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Data.Forum
{
    public class Comment
    {
        public Comment(ApplicationUser user, string content, Topic parentTopic, DateTime commentDate, Comment parentComment = null)
        {
            User = user;
            Content = content;
            ParentTopic = parentTopic;
            CommentDate = commentDate;
            ParentComment = parentComment;
        }
        public Comment ParentComment { get; set; }
        public string Content { get; set; }
        public ApplicationUser User { get; set; }
        public Topic ParentTopic { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
