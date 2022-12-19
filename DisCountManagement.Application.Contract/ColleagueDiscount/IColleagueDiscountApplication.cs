using _0_FrameWork.Application;
using ShopManagement.Application.Contract.ProductCategory;
using System.Collections.Generic;

namespace DisCountManagement.Application.Contract.ColleagueDiscount
{
    public interface IColleagueDiscountApplication
    {
        OprationResualt Difind(AddColleagueDisCount command);
        OprationResualt Edit(EditColleagueDisCount command);
        OprationResualt Delete(long id);
        OprationResualt Restore(long id);
        EditColleagueDisCount GetDetails(long id);
        List<ColleagueDisCountViewModel> Search(ColleagueDiscountSearchModel model);


    }
}
