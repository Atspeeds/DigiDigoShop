using _01_DigiDigoQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ServiceHost.ViewComponents
{
    public class LatestProductsViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;

        public LatestProductsViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public IViewComponentResult Invoke()
        {
            var model = _productQuery.GetLatestArrival().Take(6);
            return View(model);
        }

    }
}
