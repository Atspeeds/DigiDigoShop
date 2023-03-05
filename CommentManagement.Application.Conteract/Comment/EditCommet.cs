namespace CommentManagement.Application.Conteract.Comment
{
    public class EditCommet:AddComment
    {
        public long Id { get; set; }
        public bool Confirmation { get; set; }
    }
}
