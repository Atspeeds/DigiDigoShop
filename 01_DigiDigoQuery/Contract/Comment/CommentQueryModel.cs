namespace _01_DigiDigoQuery.Contract.Comment
{
    public class CommentQueryModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsConfirmation { get; set; }
        public bool IsSpam { get; set; }
    }
}