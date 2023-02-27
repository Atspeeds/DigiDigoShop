namespace CommentManagement.Application.Conteract.Comment
{
    public class AddComment
    {
        public string Name { get; set; }
        public long ProductId { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
