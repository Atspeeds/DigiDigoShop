using _0_FrameWork.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {

        private readonly IFileUploader _fileUploader;

        private readonly IProductRepository _ProductRepository;

        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductApplication(IFileUploader fileUploader, IProductRepository productRepository, IProductCategoryRepository productCategoryRepository)
        {
            _fileUploader = fileUploader;
            _ProductRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        public OprationResualt Add(CreateProduct command)
        {
            OprationResualt opration = new OprationResualt();

            if (_ProductRepository.Exists(x => x.Name == command.Name))
                return opration.Failed(ServiceMessage.DuplicateField);

            var slug = command.Slug.Slugify();


            var categoryslug = _productCategoryRepository.GetProductCategorySlugBy(command.CategoryId);

            var picturepath = $"{categoryslug}/{slug}";

            var filename = _fileUploader.Upload(command.Picture, picturepath);

            var productctegory = new Product(command.Name, command.Code, command.ShortDescription,
                command.Description, filename, command.PictureAlt,
                command.PictureTitle, command.CategoryId, slug, command.KeyWords, command.MetaDescription);

            _ProductRepository.Create(productctegory);
            _ProductRepository.Save();

            return opration.Succedded();
        }

        public OprationResualt Edit(EditProduct command)
        {
            var opration = new OprationResualt();

            var productcategory = _ProductRepository.GetWithProductCategory(command.Id);

            if (productcategory == null)
                return opration.Failed(ServiceMessage.EmptyRecord);

            if (_ProductRepository.Exists(x => x.Name == command.Name && x.KeyId != command.Id))
                return opration.Failed(ServiceMessage.DuplicateField);

            var slug = command.Slug.Slugify();

            var picturepath = $"{productcategory.Category.Slug}/{slug}";


            var filename = _fileUploader.Upload(command.Picture, picturepath);

            productcategory.Edit(command.Name, command.Code, command.ShortDescription, command.Description,
                filename, command.PictureAlt, command.PictureTitle,
                command.CategoryId, slug, command.KeyWords, command.MetaDescription);

            _ProductRepository.Save();

            return opration.Succedded();
        }

        public EditProduct GetDetails(long id)
        {
            return _ProductRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetSelectList()
        {
            return _ProductRepository.SelectList();
        }

        public IEnumerable<ProductViewModel> Search(SearchProduct searchModel)
        {
            return _ProductRepository.Search(searchModel);
        }



    }
}
