using _0_FrameWork.Application;
using InventoryManagement.Application.Contract.WareHouse;
using InventoryManagement.Domain.WareHouseAgg;
using System.Collections.Generic;

namespace InventoryManagement.Application
{
    public class WareHouseApplication : IWareHouseApplication
    {
        private readonly IWareHouseRepository _wareHouseRepository;

        public WareHouseApplication(IWareHouseRepository wareHouseRepository)
        {
            _wareHouseRepository = wareHouseRepository;
        }

        public OprationResualt Add(CreateWareHouse command)
        {
            OprationResualt opration = new OprationResualt();


            if (_wareHouseRepository.Exists(x => x.ProductId == command.ProductId))
                return opration.Failed(ServiceMessage.DuplicateField);

            var warehouse = new WareHouse(command.ProductId, command.UnitPrice);

            _wareHouseRepository.Create(warehouse);
            _wareHouseRepository.Save();

            return opration.Succedded();

        }

        public OprationResualt Edit(EditeWareHouse command)
        {
            OprationResualt opration = new OprationResualt();


            var warehouse = _wareHouseRepository.Get(command.ID);

            if (warehouse == null)
                return opration.Failed(ServiceMessage.EmptyRecord);


            if (_wareHouseRepository.Exists(x => x.ProductId == command.ProductId && x.KeyId != command.ID))
                return opration.Failed(ServiceMessage.DuplicateField);

            warehouse.Edit(command.ProductId, command.UnitPrice);
            _wareHouseRepository.Save();


            return opration.Succedded();
        }

        public EditeWareHouse GetDetails(long id)
        {
            return _wareHouseRepository.Details(id);
        }

        public OprationResualt Increase(IncreaseInventory command)
        {
            OprationResualt opration = new OprationResualt();

            var warehouse = _wareHouseRepository.Get(command.WareHouseID);

            if (warehouse == null)
                return opration.Failed(ServiceMessage.EmptyRecord);

            const long characteristic = 1;

            warehouse.InventoryIncrease(command.Count, characteristic, command.Description);
            _wareHouseRepository.Save();

            return opration.Succedded();

        }

        public OprationResualt Reduce(List<ReduceInventory> command)
        { 
            OprationResualt opration = new OprationResualt();

            const long characteristic = 1;
           
            foreach (var item in command)
            {
                var warehouse = _wareHouseRepository.GetBy(item.ProductID);

                if (warehouse == null)
                    return opration.Failed(ServiceMessage.EmptyRecord);

                warehouse.InventoryReduction(item.Count, characteristic,
                                            item.Description, item.OrderID);

            }

            _wareHouseRepository.Save();

            return opration.Succedded();
        }

        public OprationResualt Reduce(ReduceInventory command)
        {
            OprationResualt opration = new OprationResualt();

            var warehouse = _wareHouseRepository.GetBy(command.ProductID);

            if (warehouse == null)
                return opration.Failed(ServiceMessage.EmptyRecord);

            const long characteristic = 1;

            warehouse.InventoryReduction(command.Count, characteristic, command.Description, 0);
            _wareHouseRepository.Save();

            return opration.Succedded();
        }

        public List<WareHouseViewModel> Search(WareHouseSearchModel searchModel)
        {
            return _wareHouseRepository.Search(searchModel);
        }
    }
}
