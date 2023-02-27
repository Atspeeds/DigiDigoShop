﻿using System.Collections.Generic;

namespace _01_DigiDigoQuery.Contract.Product
{
    public class ProductQueryModel
    {

        public long ProductId { get; set; }
        public string Picture { get; set; }
        public string CategorySlug { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string PriceWithDiscount { get; set; }
        public int DiscountRate { get; set; }
        public string ProductCategory { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public bool Stock { get; set; }
        public List<ProductPictureQueryModel> ProductPictures { get; set; }
        public List<ProductQueryModel> ProductQueryModels { get; set; }
    }
}