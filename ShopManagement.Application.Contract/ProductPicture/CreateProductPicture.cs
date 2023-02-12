using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.ProductPicture
{
    public class CreateProductPicture
    {
        [Range(1,100000,ErrorMessage =ServiceMessage.IsRequired)]
        public long ProductId { get; set; }

        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = ServiceMessage.IsRequired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ServiceMessage.IsRequired)]
        public string PictureTitle { get; set; }

        public List<ProductViewModel> products { get; set; }
    }

}
