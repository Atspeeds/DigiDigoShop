namespace CommentManagement.Application.Conteract.Comment
{
    public class CommentSearchModel
    {
        public long ProductId { get; set; }
        public long ProductName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsCanceled { get; set; }
    }
}
