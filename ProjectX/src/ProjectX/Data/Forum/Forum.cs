using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Data.Forum
{
    public class Forum
    {
        public Forum(string title, string description = "")
        {
            Title = title;
            Description = description;
            Topics = new List<Topic>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
