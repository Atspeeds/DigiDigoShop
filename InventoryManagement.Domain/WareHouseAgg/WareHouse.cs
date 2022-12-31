using _0_FrameWork.Domain;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Domain.WareHouseAgg
{
    public class WareHouse : EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }


        //RelationShip

        //To WareHouseOpration
        public List<WareHouseOpration> Oprations { get; private set; }


        #region Add || CalculateCurrentCount || Increase || Decrease

        public WareHouse(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
        }
        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }

        public long CalculateCurrentCount()
        {
            var increase = Oprations.Where(x => x.TypeOperation).Sum(x => x.Count);

            var decrease = Oprations.Where(x => !x.TypeOperation).Sum(x => x.Count);

            return increase - decrease;
        }

        public void InventoryIncrease(long count, long Characteristic, string description)
        {
            var increase = CalculateCurrentCount() + count;

            var opration = new WareHouseOpration(KeyId, true, count, Characteristic, increase, description, 0);

            Oprations.Add(opration);

            InStock = increase > 0;
        }

        public void InventoryReduction(long count, long Characteristic, string description, long orderid)
        {
            var decrease = CalculateCurrentCount() - count;

            var opration = new WareHouseOpration(KeyId, false, count, Characteristic, decrease, description, orderid);

            Oprations.Add(opration);

            InStock = decrease > 0;
        }



        #endregion

    }


}
