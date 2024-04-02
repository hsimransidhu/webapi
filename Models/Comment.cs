using System;
namespace webapi.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public Post Post { get; set; }
    }
}

