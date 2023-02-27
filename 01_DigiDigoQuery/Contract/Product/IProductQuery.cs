using System.Collections.Generic;

namespace _01_DigiDigoQuery.Contract.Product
{
    public interface IProductQuery
    {
        List<ProductQueryModel> GetLatestArrival();
        ProductQueryModel GetDetails(string slug);  
        List<ProductQueryModel> Search(string value);
        List<ProductQueryModel> GetRelatedProductsBy(ProductRelatedQueryModel command);
    }
}
