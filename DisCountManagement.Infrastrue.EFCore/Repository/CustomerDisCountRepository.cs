using _0_FrameWork.Application;
using _0_FrameWork.Infrastrure;
using DisCountManagement.Application.Contract.CustomerDisCount;
using DisCountManagement.Domain.CustomerDisCountAgg;
using ShopManagement.Infrastrure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace DisCountManagement.Infrastrue.EFCore.Repository
{
    public class CustomerDisCountRepository : RepositoryBase<long, CustomerDisCount>, ICustomerDisCountRepository
    {
        private readonly DisCountContext _discountContext;
        private readonly ShopContext _shopContext;
        public CustomerDisCountRepository(DisCountContext dbdiscountContext, ShopContext shopContext) : base(dbdiscountContext)
        {
            _discountContext = dbdiscountContext;
            _shopContext = shopContext;
        }

        public EditCustomerDiscount Details(long id)
        {
            return _discountContext.CustomerDisCounts
                .Select(x => new EditCustomerDiscount
                {
                    Id = x.KeyId,
                    DisCountRate = x.DisCountRate,
                    EndDate = x.EndDate.ToFarsi(),
                    StartDate = x.StartDate.ToFarsi(),
                    ProductId = x.ProductId,
                    Reason = x.Reason,
                })
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<CustomerDisCountViewModel> Search(CustomerDisCountSearchModel model)
        {
            var products = _shopContext.Products.Select(x => new { x.KeyId, x.Name }).ToList();

            var query = _discountContext.CustomerDisCounts
                .Select(x => new CustomerDisCountViewModel
                {
                    Id = x.KeyId,
                    ProductId = x.ProductId,
                    DisCountRate = x.DisCountRate,
                    StartDate = x.StartDate.ToFarsi(),
                    EndDate = x.EndDate.ToFarsi(),
                    Reason = x.Reason,
                    StartDateGr = x.StartDate,
                    EndDateGr = x.EndDate,
                    DateCreation = x.CreationDate.ToFarsi()
                });

            if (model.ProductId > 0)
                query = query.Where(x => x.ProductId == model.ProductId);

            if (!string.IsNullOrWhiteSpace(model.StartDate))
            {
                query = query.Where(x => x.StartDateGr >= model.StartDate.ToGeorgianDateTime());
            }

            if (!string.IsNullOrWhiteSpace(model.EndDate))
            {
                query = query.Where(x => x.EndDateGr <= model.EndDate.ToGeorgianDateTime());
            }

            var discount = query.OrderByDescending(x => x.Id).ToList();

            discount.ForEach(discoun => discoun.Product = products.FirstOrDefault(x => x.KeyId == discoun.ProductId)?.Name);


            return discount;
        }
    }
}
