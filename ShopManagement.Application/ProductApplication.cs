using _0_FrameWork.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {

        private readonly IProductRepository _ProductRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }



        public OprationResualt Add(CreateProduct command)
        {
            OprationResualt opration = new OprationResualt();

            if (_ProductRepository.Exists(x => x.Name == command.Name))
                return opration.Failed(ServiceMessage.DuplicateField);

            var slug = command.Slug.Slugify();


            var productctegory = new Product(command.Name, command.Code, command.ShortDescription,
                command.Description, command.Picture, command.PictureAlt,
                command.PictureTitle, command.CategoryId, slug, command.KeyWords, command.MetaDescription);

            _ProductRepository.Create(productctegory);
            _ProductRepository.Save();

            return opration.Succedded();
        }

        public OprationResualt Edit(EditProduct command)
        {
            var opration = new OprationResualt();

            var productcategory = _ProductRepository.Get(command.Id);

            if (productcategory == null)
                return opration.Failed(ServiceMessage.EmptyRecord);

            if (_ProductRepository.Exists(x => x.Name == command.Name && x.KeyId != command.Id))
                return opration.Failed(ServiceMessage.DuplicateField);

            var slug = command.Slug.Slugify();


            productcategory.Edit(command.Name, command.Code, command.ShortDescription, command.Description,
                command.Picture, command.PictureAlt, command.PictureTitle,
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
