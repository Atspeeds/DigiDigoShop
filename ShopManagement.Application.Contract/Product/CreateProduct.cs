﻿using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contract.ProductCategory;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ServiceMessage.IsRequired)]
        public string Name { get; set; }


        [Required(ErrorMessage = ServiceMessage.IsRequired)]
        public string Code { get; set; }

        [Required(ErrorMessage = ServiceMessage.IsRequired)]
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = ServiceMessage.IsRequired)]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ServiceMessage.MaxFileSize)]
        [FileExtension(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ServiceMessage.InvalidFileFormat)]
        public IFormFile Picture { get; set; }

        public string PictureAlt { get; set; }

        public string PictureTitle { get; set; }

        [Range(1, 100000)]
        public long CategoryId { get; set; }
        [Required(ErrorMessage = ServiceMessage.IsRequired)]
        public string KeyWords { get; set; }

        [Required(ErrorMessage = ServiceMessage.IsRequired)]
        public string MetaDescription { get; set; }
        [Required(ErrorMessage = ServiceMessage.IsRequired)]
        public string Slug { get; set; }

        public List<ProductCategoryViewModel> Categories { get; set; }

    }
}