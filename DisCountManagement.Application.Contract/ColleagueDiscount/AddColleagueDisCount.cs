using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;
using System.Security.Principal;

namespace DisCountManagement.Application.Contract.ColleagueDiscount
{
    public class AddColleagueDisCount
    {
        public long ProductId { get; set; }
        public int DisCountRate { get; set; }
        public List<ProductViewModel> productViews { get; set; }
    }

}
