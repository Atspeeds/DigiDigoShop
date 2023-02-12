using _0_FrameWork.Application;
using ShopManagement.Application.Contract.Slide;
using ShopManagement.Domain.SlideAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;
        private readonly IFileUploader _fileUploader;

        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _slideRepository = slideRepository;
            _fileUploader = fileUploader;
        }

        public OprationResualt Add(CreateSlide command)
        {
            OprationResualt opration = new OprationResualt();

            if (_slideRepository.Exists(x => x.Heading == command.Heading || x.Text == command.Text))
                return opration.Failed(ServiceMessage.DuplicateField);

            var filepath = _fileUploader.Upload(command.Picture, "Slide");

            var slider = new Slide(filepath, command.PictureAlt, command.PictureTitle,
                    command.Heading, command.Title, command.Text, command.BtnText,command.Link);

            _slideRepository.Create(slider);
            _slideRepository.Save();

            return opration.Succedded();
        }

        public IEnumerable<SlideViewModel> All()
        {
            return _slideRepository.GetAll();
        }

        public OprationResualt Delete(long id)
        {
            OprationResualt opration = new OprationResualt();

            var slider = _slideRepository.Get(id);

            if (slider == null)
                return opration.Failed(ServiceMessage.EmptyRecord);

            if (!slider.IsRemove)
            {
                slider.Remove();
                _slideRepository.Save();
            }

            return opration.Succedded();    

        }

        public OprationResualt Edit(EditSlide command)
        {
            OprationResualt opration = new OprationResualt();

            var slider = _slideRepository.Get(command.Id);

            if (slider == null)
                return opration.Failed(ServiceMessage.EmptyRecord);

            var filepath = _fileUploader.Upload(command.Picture, "Slide");

            slider.Edit(filepath, command.PictureAlt, command.PictureTitle,
                command.Heading, command.Title, command.Text, command.BtnText, command.Link);

            _slideRepository.Save();

            return opration.Succedded();

        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public OprationResualt Restore(long id)
        {
            OprationResualt opration = new OprationResualt();

            var slider = _slideRepository.Get(id);

            if (slider == null)
                return opration.Failed(ServiceMessage.EmptyRecord);

            if (slider.IsRemove)
            {
                slider.Restore();
                _slideRepository.Save();
            }

            return opration.Succedded();
        }
    }
}
