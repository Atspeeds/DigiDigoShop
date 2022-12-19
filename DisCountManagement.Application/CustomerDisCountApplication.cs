using _0_FrameWork.Application;
using DisCountManagement.Application.Contract.CustomerDisCount;
using DisCountManagement.Domain.CustomerDisCountAgg;
using System.Collections.Generic;

namespace DisCountManagement.Application
{
    public class CustomerDisCountApplication : ICustomerDisCountApplication
    {
        private readonly ICustomerDisCountRepository _customerDisCountRepository;

        public CustomerDisCountApplication(ICustomerDisCountRepository customerDisCountRepository)
        {
            _customerDisCountRepository = customerDisCountRepository;
        }

        public OprationResualt Defind(AddCustomerDiscount command)
        {
            OprationResualt resualt = new OprationResualt();

            if (_customerDisCountRepository.Exists(x => x.ProductId ==
            command.ProductId && x.DisCountRate == command.DisCountRate))
                resualt.Failed(ServiceMessage.DuplicateField);

            var customerdiscount = new CustomerDisCount(command.ProductId, command.StartDate.ToGeorgianDateTime(),
                command.EndDate.ToGeorgianDateTime(), command.DisCountRate, command.Reason);

            _customerDisCountRepository.Create(customerdiscount);
            _customerDisCountRepository.Save();

            return resualt.Succedded();
        }

        public OprationResualt Edit(EditCustomerDiscount command)
        {
            OprationResualt resualt = new OprationResualt();

            var customerdiscount = _customerDisCountRepository.Get(command.Id);

            if (customerdiscount == null)
                return resualt.Failed(ServiceMessage.EmptyRecord);

            if (_customerDisCountRepository.Exists(x => x.DisCountRate ==
            customerdiscount.DisCountRate && x.ProductId == customerdiscount.ProductId &&
            x.KeyId != customerdiscount.KeyId))
                return resualt.Failed(ServiceMessage.DuplicateField);

            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();

            customerdiscount.Edit(command.ProductId, startDate,
                endDate, command.DisCountRate, command.Reason);

            _customerDisCountRepository.Save();

            return resualt.Succedded();
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _customerDisCountRepository.Details(id);
        }

        public IEnumerable<CustomerDisCountViewModel> Search(CustomerDisCountSearchModel searchModel)
        {
            return _customerDisCountRepository.Search(searchModel);
        }
    }
}
