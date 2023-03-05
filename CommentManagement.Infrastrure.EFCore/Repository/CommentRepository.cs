using _0_FrameWork.Application;
using _0_FrameWork.Infrastrure;
using CommentManagement.Application.Conteract.Comment;
using CommentManagement.Domain.CommentAgg;
using ShopManagement.Infrastrure.EFCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CommentManagement.Infrastrure.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly CommentContext _commentContext;
        private readonly ShopContext _shopContext;
        public CommentRepository(CommentContext commentContext, ShopContext shopContext) : base(commentContext)
        {
            _commentContext = commentContext;
            _shopContext = shopContext;
        }

        public EditCommet Detail(long id)
        {
            var comment = Get(id);
            return new EditCommet()
            {
                Id = comment.KeyId,
                Message = comment.Message,
                Name = comment.Name,
                Confirmation = comment.IsConfirmation
            };
        }

        public List<CommentViewModel> Search(CommentSearchModel model)
        {
            var query = _commentContext.Comments.
                Select(x => new CommentViewModel
                {
                    Id = x.KeyId,
                    Email = x.Email,
                    Message = x.Message,
                    IsConfirmation = x.IsConfirmation,
                    IsSpam = x.IsSpam,
                    Name = x.Name,
                    ProductId = x.ProductId,
                    CreationDate = x.CreationDate.ToFarsi()
                });

            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(model.Name));
            }

            if (!string.IsNullOrWhiteSpace(model.Email))
            {
                query = query.Where(x => x.Email.ToLower().Contains(model.Email));
            }

            if (model.IsCanceled)
            {
                query = query.Where(x => !x.IsConfirmation);
            }

            if (model.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == model.ProductId);
            }

            var comment = query.OrderByDescending(x => x.ProductId).ToList();

            comment.ForEach(x => x.ProductName = _shopContext.Products
            .FirstOrDefault(p => p.KeyId == x.ProductId).Name);

            return comment;

        }
    }
}
