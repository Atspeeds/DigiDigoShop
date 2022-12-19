using _0_FrameWork.Application;
using _0_FrameWork.Infrastrure;
using DisCountManagement.Application.Contract.ColleagueDiscount;
using DisCountManagement.Domain.ColleagueDiscountAgg;
using ShopManagement.Infrastrure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace DisCountManagement.Infrastrue.EFCore.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DisCountContext _DiscountContext;
        private readonly ShopContext _shopContext;

        public ColleagueDiscountRepository(DisCountContext discountContext, ShopContext shopContext):base(discountContext)
        {
            _DiscountContext = discountContext;
            _shopContext = shopContext;
        }

        public EditColleagueDisCount Details(long id)
        {
            return _DiscountContext.ColleagueDiscounts
                .Select(x => new EditColleagueDisCount()
                {
                    Id = x.KeyId,
                    DisCountRate = x.DisCountRate,
                    ProductId = x.ProductId
                })
               .FirstOrDefault(x => x.Id == id);
        }

        public List<ColleagueDisCountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            var Products = _shopContext.Products.ToList();

            var query = _DiscountContext.ColleagueDiscounts
                .Select(x => new ColleagueDisCountViewModel()
                {
                    Id = x.KeyId,
                    DisCountRate = x.DisCountRate,
                    CreationDate = x.CreationDate.ToFarsi(),
                    IsRemoved = x.IsRemove
                });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

           var Discount = query.OrderByDescending(x => x.Id).ToList();

            Discount.ForEach(x => x.Product = Products.FirstOrDefault(p => p.KeyId == x.ProductId)?.Name);

            return Discount;
        }
    }
}
