using _0_FrameWork.Application;
using DisCountManagement.Application.Contract.ColleagueDiscount;
using DisCountManagement.Domain.ColleagueDiscountAgg;
using System.Collections.Generic;

namespace DisCountManagement.Application
{
    internal class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OprationResualt Delete(long id)
        {
            OprationResualt resualt = new OprationResualt();

            var colleaguediscount = _colleagueDiscountRepository.Get(id);

            if (colleaguediscount != null)
                return resualt.Failed(ServiceMessage.EmptyRecord);

            if (colleaguediscount.IsRemove == false)
            {
                colleaguediscount.Removed();
                _colleagueDiscountRepository.Save();
            }


            return resualt.Succedded();
        }

        public OprationResualt Difind(AddColleagueDisCount command)
        {
            OprationResualt resualt = new OprationResualt();

            if (command != null)
                return resualt.Failed(ServiceMessage.EmptyRecord);

            if (_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId &&
             x.DisCountRate == command.DisCountRate))
                return resualt.Failed(ServiceMessage.DuplicateField);

            var colleagueDisCount = new ColleagueDiscount(command.ProductId,
                command.DisCountRate);

            _colleagueDiscountRepository.Save();

            return resualt.Succedded();

        }

        public OprationResualt Edit(EditColleagueDisCount command)
        {
            OprationResualt resualt = new OprationResualt();

            var colleaguediscount = _colleagueDiscountRepository.Get(command.Id);

            if (colleaguediscount != null)
                return resualt.Failed(ServiceMessage.EmptyRecord);

            if (_colleagueDiscountRepository.Exists(x => x.KeyId != command.Id &&
             x.ProductId == command.ProductId && x.DisCountRate == command.DisCountRate))
                return resualt.Failed(ServiceMessage.DuplicateField);

            colleaguediscount.Edit(command.ProductId, command.DisCountRate);
            _colleagueDiscountRepository.Save();

            return resualt.Succedded();
        }

        public EditColleagueDisCount GetDetails(long id)
        {
            return _colleagueDiscountRepository.Details(id);
        }

        public OprationResualt Restore(long id)
        {
            OprationResualt resualt = new OprationResualt();

            var colleaguediscount = _colleagueDiscountRepository.Get(id);

            if (colleaguediscount != null)
                return resualt.Failed(ServiceMessage.EmptyRecord);

            if (colleaguediscount.IsRemove == true)
            {
                colleaguediscount.Restore();
                _colleagueDiscountRepository.Save();
            }


            return resualt.Succedded();
        }

        public List<ColleagueDisCountViewModel> Search(ColleagueDiscountSearchModel model)
        {
            return _colleagueDiscountRepository.Search(model);
        }
    }
}
