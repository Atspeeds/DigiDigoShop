using _0_FrameWork.Domain;
using InventoryManagement.Application.Contract.WareHouse;
using System.Collections.Generic;

namespace InventoryManagement.Domain.WareHouseAgg
{
    public interface IWareHouseRepository: IRepositoryBase<long,WareHouse>
    {
        List<WareHouseViewModel> Search(WareHouseSearchModel searchModel);
        EditeWareHouse Details(long id);
        WareHouse GetBy(long productid);
        List<WareHouseOprationViewModel> GetWareHousesOpration(long id); 

    }
}
