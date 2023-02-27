using _01_DigiDigoQuery.Contract.Product;
using System.Collections.Generic;

namespace _01_DigiDigoQuery.Contract.ProductCategory
{
    public class ProductCategoryQueryModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string CategorySlug { get; set; }
        public IEnumerable<ProductQueryModel> Products { get; set; }
        public string Description { get; set; }
    }
}
