using _0_FrameWork.Domain;
using DisCountManagement.Application.Contract.ColleagueDiscount;
using System.Collections.Generic;

namespace DisCountManagement.Domain.ColleagueDiscountAgg
{
    public interface IColleagueDiscountRepository : IRepositoryBase<long, ColleagueDiscount>
    {
        List<ColleagueDisCountViewModel> Search(ColleagueDiscountSearchModel searchModel);
        EditColleagueDisCount Details(long id);
    }
}
