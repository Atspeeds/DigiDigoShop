using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;

namespace DisCountManagement.Application.Contract.CustomerDisCount
{
    public class AddCustomerDiscount
    {

        public long ProductId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int DisCountRate { get; set; }
        public string Reason { get; set; }
        public List<ProductViewModel> productViews { get; set; }
    }

}
