using _0_FrameWork.Domain;
using CommentManagement.Application.Conteract.Comment;
using System.Collections.Generic;

namespace CommentManagement.Domain.CommentAgg
{
    public interface ICommentRepository : IRepositoryBase<long, Comment>
    {
        List<CommentViewModel> Search(CommentSearchModel model);
        EditCommet Detail(long id);
    }
}
