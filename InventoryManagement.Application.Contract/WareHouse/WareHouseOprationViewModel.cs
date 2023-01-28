using System;

namespace InventoryManagement.Application.Contract.WareHouse
{
    public class WareHouseOprationViewModel
    {
        public long WareHouseID { get; set; }
        public bool TypeOperation { get; set; } //Out = 0 : come in = 1
        public long Count { get; set; }
        public long Characteristic { get; set; }
        public string Character { get; set; }
        public string OprationDate { get; set; }
        public long CurrentCount { get; set; }
        public string Description { get; set; }
    }
}
