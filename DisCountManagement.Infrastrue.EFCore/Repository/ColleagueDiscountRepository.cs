using _0_FrameWork.Application;
using _0_FrameWork.Infrastrure;
using DisCountManagement.Application.Contract.ColleagueDiscount;
using DisCountManagement.Domain.ColleagueDiscountAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
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
            var products = _shopContext.Products.Select(x => new { x.KeyId, x.Name }).ToList();

            var query = _DiscountContext.ColleagueDiscounts.Select(x => new ColleagueDisCountViewModel
            {
                Id = x.KeyId,
                CreationDate = x.CreationDate.ToFarsi(),
                DisCountRate = x.DisCountRate,
                ProductId = x.ProductId,
                IsRemoved = x.IsRemove
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            var discounts = query.OrderByDescending(x => x.Id).ToList();

            discounts.ForEach(discount =>
                discount.Product = products.FirstOrDefault(x => x.KeyId == discount.ProductId)?.Name);

            return discounts;
        }
    }
}
