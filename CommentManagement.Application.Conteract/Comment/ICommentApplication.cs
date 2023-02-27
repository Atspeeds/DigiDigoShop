using _0_FrameWork.Application;
using System.Collections.Generic;

namespace CommentManagement.Application.Conteract.Comment
{
    public interface ICommentApplication
    {
        OprationResualt Add(AddComment comment);
        OprationResualt Reject(long id);
        OprationResualt Confirmation(long id);
        OprationResualt Spam(long id);
        List<CommentViewModel> GetComments();
        List<CommentViewModel> SearchBy(CommentSearchModel model);
    }
}
