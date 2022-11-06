using _0_FrameWork.Application;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {

        private readonly IProductCategoryRepository _ProductCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _ProductCategoryRepository = productCategoryRepository;
        }

        public OprationResualt Add(CreateProductCategory command)
        {
            OprationResualt opration = new OprationResualt();

            if (_ProductCategoryRepository.Exists(x => x.Name == command.Name))
               return opration.Failed(ServiceMessage.DuplicateField);

            var slug = command.Slug.Slugify();


            var productctegory = new ProductCategory(command.Name,
                    command.Description, command.Picture, command.PictureAlt,
                    command.PictureTitle, command.KeyWords, command.MetaDescription, slug);

            _ProductCategoryRepository.Create(productctegory);
            _ProductCategoryRepository.Save();

            return opration.Succedded();

        }

        public OprationResualt Edit(EditProductCategory command)
        {
            var opration = new OprationResualt();

            var productcategory = _ProductCategoryRepository.Get(command.Id);

            if (productcategory == null)
                return opration.Failed(ServiceMessage.EmptyRecord);

            if (_ProductCategoryRepository.Exists(x => x.Name == command.Name && x.KeyId != command.Id))
                return opration.Failed(ServiceMessage.DuplicateField);

            var slug = command.Slug.Slugify();


            productcategory.Edit(command.Name, command.Description, command.Picture, command.PictureAlt,
                 command.PictureTitle, command.KeyWords, command.MetaDescription, slug);

            _ProductCategoryRepository.Save();

            return opration.Succedded();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _ProductCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> GetSelectList()
        {
            return _ProductCategoryRepository.GetProductCategories();
        }

        public IEnumerable<ProductCategoryViewModel> Search(SearchProductCategory searchModel)
        {
           return _ProductCategoryRepository.Search(searchModel);
        }

    }
}
