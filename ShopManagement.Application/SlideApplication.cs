using _0_FrameWork.Application;
using ShopManagement.Application.Contract.Slide;
using ShopManagement.Domain.SlideAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public OprationResualt Add(CreateSlide command)
        {
            OprationResualt opration = new OprationResualt();

            if (_slideRepository.Exists(x => x.Heading == command.Heading || x.Text == command.Text))
                return opration.Failed(ServiceMessage.DuplicateField);

            var slider = new Slide(command.Picture, command.PictureAlt, command.PictureTitle,
                    command.Heading, command.Title, command.Text, command.BtnText);

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


            slider.Edit(command.Picture, command.PictureAlt, command.PictureTitle,
                command.Heading, command.Title, command.Text, command.BtnText);

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
