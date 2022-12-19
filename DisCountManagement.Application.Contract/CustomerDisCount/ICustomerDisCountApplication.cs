using _0_FrameWork.Application;
using System.Collections.Generic;

namespace DisCountManagement.Application.Contract.CustomerDisCount
{
    public interface ICustomerDisCountApplication
    {
        OprationResualt Defind(AddCustomerDiscount command);
        OprationResualt Edit(EditCustomerDiscount command);
        EditCustomerDiscount GetDetails(long id);
        IEnumerable<CustomerDisCountViewModel> Search(CustomerDisCountSearchModel searchModel);
    }
}
