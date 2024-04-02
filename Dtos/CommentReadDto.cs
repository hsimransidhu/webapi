


namespace webapi.Dtos
{
    public class CommentReadDto
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
