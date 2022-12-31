using System;

namespace InventoryManagement.Domain.WareHouseAgg
{
    public class WareHouseOpration
    {
        public long Id { get; private set; }
        public long WareHouseID { get; private set; }
        public bool TypeOperation { get; private set; } //Out = 0 : come in = 1
        public long Count { get; private set; }
        public long Characteristic { get; private set; }
        public DateTime OprationDate { get; private set; }
        public long CurrentCount { get; private set; }
        public string Description { get; private set; }
        /// <summary>
        /// If based on customer order, customer order number
        /// </summary>
        public long OrderId { get; private set; }


        //RelationShip

        //To WareHouse
        public WareHouse WareHouse { get; private set; }


        #region Add
        public WareHouseOpration(long wareHouseID, bool typeOperation, long count,
           long characteristic, long currentCount, string description, long orderId)
        {
            WareHouseID = wareHouseID;
            TypeOperation = typeOperation;
            Count = count;
            Characteristic = characteristic;
            CurrentCount = currentCount;
            Description = description;
            OrderId = orderId;
        }

        #endregion


    }


}
