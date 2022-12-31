namespace InventoryManagement.Application.Contract.WareHouse
{
    public class ReduceInventory
    {
        public long ProductID { get; set; }
        public long OrderID { get; set; }
        public long Count { get; set; }
        public string Description { get; set; }

    }
}
