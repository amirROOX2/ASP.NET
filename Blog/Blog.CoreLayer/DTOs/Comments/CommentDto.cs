namespace Blog.CoreLayer.DTOs.Comments
{
    public class CommentDto
    {
        public int CommentID { get; set; }
        public string UserFullName { get; set; }
        public int PostID { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
