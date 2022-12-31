using _0_FrameWork.Application;
using System.Collections.Generic;

namespace InventoryManagement.Application.Contract.WareHouse
{
    public interface IWareHouseApplication
    {
        OprationResualt Add(CreateWareHouse command);
        OprationResualt Edit(EditeWareHouse command);
        OprationResualt Increase(IncreaseInventory command);
        OprationResualt Reduce(List<ReduceInventory> command);
        OprationResualt Reduce(ReduceInventory command);
        EditeWareHouse GetDetails(long id);
        List<WareHouseViewModel> Search(WareHouseSearchModel searchModel);

    }
}
