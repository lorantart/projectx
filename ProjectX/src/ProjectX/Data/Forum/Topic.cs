using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Data.Forum
{
    public class Topic
    {
        public Topic(string title, Forum parentForum = null)
        {
            Title = title;
            ParentForum = parentForum;
            Comments = new List<Comment>();
        }
        public string Title { get; set; }
        public Forum ParentForum { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
