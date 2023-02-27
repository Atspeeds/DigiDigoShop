using _01_DigiDigoQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;

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
            var model = _productQuery.GetLatestArrival();
            return View(model);
        }

    }
}
