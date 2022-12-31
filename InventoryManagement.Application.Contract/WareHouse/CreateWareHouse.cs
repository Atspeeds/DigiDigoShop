using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;

namespace InventoryManagement.Application.Contract.WareHouse
{
    public class CreateWareHouse
    {
        public long ProductId { get; set; }
        public double UnitPrice { get; set; }
        public List<ProductViewModel> ProductViews { get; set; }
    }
}
