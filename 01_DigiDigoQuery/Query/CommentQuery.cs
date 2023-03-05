using _01_DigiDigoQuery.Contract.Comment;
using CommentManagement.Application.Conteract.Comment;
using CommentManagement.Infrastrure.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace _01_DigiDigoQuery.Query
{
    public class CommentQuery : ICommentQuery
    {

        private readonly CommentContext _commentContext;

        private readonly ICommentApplication _commentApplication;

        public CommentQuery(CommentContext commentContext, ICommentApplication commentApplication)
        {
            _commentContext = commentContext;
            _commentApplication = commentApplication;
        }

        public string Add(AddCommentQueryModel command)
        {
            var resualt = _commentApplication.Add(command);
            return resualt.Message;
        }

        public List<CommentQueryModel> GetAll(long productid)
        {

            var comment = _commentContext.Comments
                .Where(p => p.ProductId == productid && p.IsConfirmation)
                .Select(x => new CommentQueryModel()
                {
                    Id = x.KeyId,
                    ProductId = x.ProductId,
                    IsConfirmation = x.IsConfirmation,
                    Email = x.Email,
                    IsSpam = x.IsSpam,
                    Message = x.Message,
                    Name = x.Name,
                }).AsNoTracking().OrderByDescending(c => c.Id).ToList();


            return comment;
        }
    }
}
