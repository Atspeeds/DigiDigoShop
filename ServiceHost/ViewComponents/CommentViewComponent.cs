using _01_DigiDigoQuery.Contract.Comment;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class CommentViewComponent : ViewComponent
    {
        private readonly ICommentQuery _commentQuery;

        public CommentViewComponent(ICommentQuery commentQuery)
        {
            _commentQuery = commentQuery;
        }

        public IViewComponentResult Invoke(long id)
        {
            var comments = _commentQuery.GetAll(id);
            return View(comments);
        }
    }
}
