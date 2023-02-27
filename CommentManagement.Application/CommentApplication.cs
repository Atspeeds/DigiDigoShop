using _0_FrameWork.Application;
using CommentManagement.Application.Conteract.Comment;
using CommentManagement.Domain.CommentAgg;
using System.Collections.Generic;

namespace CommentManagement.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _comentRepository;

        public CommentApplication(ICommentRepository comentRepository)
        {
            _comentRepository = comentRepository;
        }

        public OprationResualt Add(AddComment comment)
        {
            OprationResualt opration = new OprationResualt();

            if (_comentRepository.Exists(x => x.Name == comment.Name ||
            x.Email == x.Email && x.Message == x.Message))
                return opration.Failed(ServiceMessage.DuplicateMessage);

            
            var comments = new Comment(comment.Name, comment.Email, comment.Message);

            _comentRepository.Create(comments);
            _comentRepository.Save();

            return opration.Succedded();

        }

        public OprationResualt Confirmation(long id)
        {
            OprationResualt opration = new OprationResualt();

            var comment = _comentRepository.Get(id);

            if (comment is null) return opration.Failed(ServiceMessage.EmptyRecord);

            comment.Confirmation();
            _comentRepository.Save();

            return opration.Succedded();

        }

        public List<CommentViewModel> GetComments()
        {
            throw new System.NotImplementedException();
        }

        public OprationResualt Reject(long id)
        {
            OprationResualt opration = new OprationResualt();

            var comment = _comentRepository.Get(id);

            if (comment is null) return opration.Failed(ServiceMessage.EmptyRecord);

            comment.Rejection();
            _comentRepository.Save();

            return opration.Succedded();
        }

        public List<CommentViewModel> SearchBy(CommentSearchModel model)
        {
           return _comentRepository.Search(model);
        }

        public OprationResualt Spam(long id)
        {
            OprationResualt opration = new OprationResualt();

            var comment = _comentRepository.Get(id);

            if (comment is null) return opration.Failed(ServiceMessage.EmptyRecord);

            comment.Spam();
            _comentRepository.Save();

            return opration.Succedded();
        }
    }
}
