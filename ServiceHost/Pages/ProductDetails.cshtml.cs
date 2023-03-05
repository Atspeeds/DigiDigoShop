using _01_DigiDigoQuery.Contract.Comment;
using _01_DigiDigoQuery.Contract.Product;
using _01_DigiDigoQuery.Contract.ProductCategory;
using CommentManagement.Application.Conteract.Comment;
using CommentManagement.Domain.CommentAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace ServiceHost.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly IProductQuery _productQuery;

        private readonly ICommentQuery _commentQuery;

        public ProductDetailsModel(IProductQuery productQuery, ICommentQuery commentQuery)
        {
            _productQuery = productQuery;
            _commentQuery = commentQuery;
        }

        public ProductQueryModel ProductModel;


        public void OnGet(string id)
        {
            ProductModel = _productQuery.GetDetails(id);

            ProductModel.ProductQueryModels = _productQuery.GetRelatedProductsBy(new ProductRelatedQueryModel(
                                            ProductModel.CategorySlug, ProductModel.ProductId));

        }
        public JsonResult OnPostAddComment(AddCommentQueryModel comment) 
        {
            ViewData["MessageCommentAdd"] = _commentQuery.Add(comment);
            return new JsonResult(ViewData["MessageCommentAdd"]);
        }
    }
}
