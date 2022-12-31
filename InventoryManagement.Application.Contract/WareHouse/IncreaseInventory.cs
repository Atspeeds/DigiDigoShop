namespace InventoryManagement.Application.Contract.WareHouse
{
    public class IncreaseInventory
    {
        public long WareHouseID { get; set; }
        public long Count { get; set; }
        public string Description { get; set; }
    }
}
