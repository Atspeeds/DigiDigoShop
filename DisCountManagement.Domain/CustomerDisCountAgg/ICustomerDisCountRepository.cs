using _0_FrameWork.Domain;
using DisCountManagement.Application.Contract.CustomerDisCount;
using System.Collections.Generic;

namespace DisCountManagement.Domain.CustomerDisCountAgg
{
    public interface ICustomerDisCountRepository : IRepositoryBase<long, CustomerDisCount>
    {
        EditCustomerDiscount Details(long id);
        IEnumerable<CustomerDisCountViewModel> Search(CustomerDisCountSearchModel model);
    }

}
