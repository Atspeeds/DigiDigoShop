namespace CommentManagement.Application.Conteract.Comment
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsConfirmation { get; set; }
        public bool IsSpam { get; set; }
        public string ProductName { get; set; }
        public long ProductId { get; set; }
        public string CreationDate { get; set; }

    }
}
