namespace InventoryManagement.Application.Contract.WareHouse
{
    public class WareHouseViewModel
    {
        public long ID { get; set; }
        public string Product { get; set; }
        public long ProductID { get; set; }
        public double UnitPrice { get; set; }
        public long CurrentCount { get; set; }
        public bool InStock { get; set; }
    }
}
