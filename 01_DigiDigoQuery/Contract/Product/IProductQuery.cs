using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DigiDigoQuery.Contract.Product
{
    public interface IProductQuery
    {
        List<ProductQueryModel> GetLatestArrival();
        ProductQueryModel GetDetails(string slug);

    }
}
