using _0_FrameWork.Application;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        public ProductPictureApplication(IProductPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }

        private readonly IProductPictureRepository _pictureRepository;


        public OprationResualt Add(CreateProductPicture command)
        {
            OprationResualt opration = new OprationResualt();
            //To:Do
            if (_pictureRepository.Exists(x => x.Picture == command.Picture || x.ProductId == command.ProductId))
                return opration.Failed(ServiceMessage.DuplicateField);

            var productpicture = new ProductPicture(command.ProductId, command.Picture,
                            command.PictureAlt, command.PictureTitle);

            _pictureRepository.Create(productpicture);
            return opration.Succedded();
        }

        public OprationResualt Deleted(long id)
        {
            OprationResualt opration = new OprationResualt();

            var picture = _pictureRepository.Get(id);

            if (picture == null)
                return opration.Failed(ServiceMessage.EmptyRecord);

            if (picture.IsRemove == true)
            {
                picture.Remove();
                _pictureRepository.Save();
            }

            return opration.Succedded();

        }

        public OprationResualt Edit(EditProductPicture command)
        {
            OprationResualt opration = new OprationResualt();

            var picture = _pictureRepository.Get(command.Id);

            if (picture == null)
                return opration.Failed(ServiceMessage.EmptyRecord);

            if (_pictureRepository.Exists(x => x.Picture == command.Picture || x.ProductId == command.ProductId))
                return opration.Failed(ServiceMessage.DuplicateField);

            picture.Edit(command.ProductId, command.Picture, command.PictureAlt, command.PictureAlt);
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

            if (picture.IsRemove == false)
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
