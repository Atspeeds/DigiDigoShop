using _0_FrameWork.Application;
using _0_FrameWork.Infrastrure;
using InventoryManagement.Application.Contract.WareHouse;
using InventoryManagement.Domain.WareHouseAgg;
using ShopManagement.Infrastrure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Infrastrure.EFCore.Repository
{
    public class WareHouseRepository : RepositoryBase<long, WareHouse>, IWareHouseRepository
    {
        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext _shopContext;
        public WareHouseRepository(InventoryContext inventoryContext, ShopContext shopContext) : base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
            _shopContext = shopContext;
        }

        public EditeWareHouse Details(long id)
        {
            var warehouse = _inventoryContext.WareHouses
                .Select(x => new EditeWareHouse
                {
                    ID = x.KeyId,
                    ProductId = x.ProductId,
                    UnitPrice = x.UnitPrice
                })
            .FirstOrDefault(x => x.ID == id);

            return warehouse;
        }

        public WareHouse GetBy(long productid)
        {
            return _inventoryContext.WareHouses
               .FirstOrDefault(x => x.ProductId == productid);
        }

        public List<WareHouseOprationViewModel> GetWareHousesOpration(long id)
        {
            var Invantory = _inventoryContext.WareHouses.FirstOrDefault(x => x.KeyId == id);

            return Invantory.Oprations.Select(x => new WareHouseOprationViewModel
            {
                WareHouseID = x.Id,
                Characteristic = x.Characteristic,
                Character = "مدیر سیستم",
                Description = x.Description,
                OprationDate = x.OprationDate.ToFarsi(),
                Count = x.Count,
                CurrentCount = x.CurrentCount,
                TypeOperation = x.TypeOperation
            }).ToList();
        }

        public List<WareHouseViewModel> Search(WareHouseSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.KeyId, x.Name }).ToList();

            var query = _inventoryContext.WareHouses
                .Select(x => new WareHouseViewModel()
                {
                    ID = x.KeyId,
                    CurrentCount = x.CalculateCurrentCount(),
                    InStock = x.InStock,
                    ProductID = x.ProductId,
                    UnitPrice = x.UnitPrice,
                });

            if (searchModel.ProductID > 0)
                query = query.Where(x => x.ProductID == searchModel.ProductID);

            if (searchModel.InStock)
                query = query.Where(x => !x.InStock);


            var wareHouse = query.OrderByDescending(x => x.ID).ToList();

            wareHouse.ForEach(x => x.Product = products.FirstOrDefault(p => p.KeyId == x.ProductID).Name);

            return wareHouse;
        }
    }
}
