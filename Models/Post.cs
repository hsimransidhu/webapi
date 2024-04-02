using System;
using System.Xml.Linq;

namespace webapi.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}

