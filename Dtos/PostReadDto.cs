﻿namespace webapi.Dtos
{
    public class PostReadDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }

   
    }
}
