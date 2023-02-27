namespace _01_DigiDigoQuery.Contract.Product
{
    public class ProductRelatedQueryModel
    {
        public string CategorySlug { get; set; }
        public long ProductId { get; set; }

        public ProductRelatedQueryModel(string categorySlug, long productId)
        {
            CategorySlug = categorySlug;
            ProductId = productId;
        }
    }
}
