using _0_FrameWork.Application;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {

        private readonly IProductPictureRepository _pictureRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;

        public ProductPictureApplication(IProductPictureRepository pictureRepository, IProductRepository productRepository, IFileUploader fileUploader)
        {
            _pictureRepository = pictureRepository;
            _productRepository = productRepository;
            _fileUploader = fileUploader;
        }

        public OprationResualt Add(CreateProductPicture command)
        {
            OprationResualt opration = new OprationResualt();
            //To:Do
            //if (_pictureRepository.Exists(x => x.Picture == command.Picture || x.ProductId == command.ProductId))
            //    return opration.Failed(ServiceMessage.DuplicateField);

            //var path = categoryslug, productslug;
            var productwithcategory = _productRepository.GetWithProductCategory(command.ProductId);


            var path = $"{productwithcategory.Category.Slug}/{productwithcategory.Slug}";

            var filename = _fileUploader.Upload(command.Picture, path);

            var productpicture = new ProductPicture(command.ProductId, filename,
                            command.PictureAlt, command.PictureTitle);

            _pictureRepository.Create(productpicture);
            _pictureRepository.Save();
            return opration.Succedded();
        }

        public OprationResualt Deleted(long id)
        {
            OprationResualt opration = new OprationResualt();

            var picture = _pictureRepository.Get(id);

            if (picture == null)
                return opration.Failed(ServiceMessage.EmptyRecord);

            if (picture.IsRemove == false)
            {
                picture.Remove();
                _pictureRepository.Save();
            }

            return opration.Succedded();

        }

        public OprationResualt Edit(EditProductPicture command)
        {
            OprationResualt opration = new OprationResualt();

            var picture = _pictureRepository.GetWithProductAndCategory(command.Id);

            if (picture == null)
                return opration.Failed(ServiceMessage.EmptyRecord);

            //if (_pictureRepository.Exists(x => x.Picture == command.Picture &&
            //x.ProductId == command.ProductId && x.KeyId != command.Id))
            //    return opration.Failed(ServiceMessage.DuplicateField);

            var path = $"{picture.Product.Category.Slug}/{picture.Product.Slug}";
            var filename = _fileUploader.Upload(command.Picture, path);


            picture.Edit(command.ProductId, filename, command.PictureAlt, command.PictureAlt);
            _pictureRepository.Save();

            return opration.Succedded();
        }

        public EditProductPicture GetDetails(long id)
        {
            return _pictureRepository.GetDetails(id);
        }

        public OprationResualt Restore(long id)
        {
            OprationResualt opration = new OprationResualt();

            var picture = _pictureRepository.Get(id);

            if (picture == null)
                return opration.Failed(ServiceMessage.EmptyRecord);

            if (picture.IsRemove == true)
            {
                picture.Restore();
                _pictureRepository.Save();
            }

            return opration.Succedded();
        }

        public IEnumerable<ProductPictureViewModel> Search(SearchProductPicture searchmodel)
        {
            return _pictureRepository.Search(searchmodel);
        }

    }
}
