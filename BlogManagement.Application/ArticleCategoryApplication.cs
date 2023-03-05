using _0_FrameWork.Application;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using System.Collections.Generic;

namespace BlogManagement.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {

        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IFileUploader fileUploader)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OprationResualt Add(CreateArticleCategory command)
        {
            OprationResualt opration = new OprationResualt();

            if (_articleCategoryRepository.Exists(a => a.Name == command.Name))
                opration.Failed(ServiceMessage.DuplicateField);

            var slug = command.Slug.Slugify();
            string pictureName = _fileUploader.Upload(command.Picture, slug);

            var articleCategory = new ArticleCategory(command.Name, command.Description, command.ShortDescription,
                                                   pictureName, command.ShowOrder,
                                                   command.CanonicalAddress, command.KeyWords,
                                                   command.MetaDescription, slug);


            _articleCategoryRepository.Create(articleCategory);

            _articleCategoryRepository.Save();

            return opration.Succedded();

        }

        public OprationResualt Edit(EditArticleCategory command)
        {
            OprationResualt opration = new OprationResualt();


            if (_articleCategoryRepository.Exists(a => a.Name == command.Name && a.KeyId != command.Id))
                opration.Failed(ServiceMessage.DuplicateField);

            var articaleCategory = _articleCategoryRepository.Get(command.Id);

            if (articaleCategory is null) return opration.Failed(ServiceMessage.EmptyRecord);

            var slug = command.Slug.Slugify();
            string pictureName = _fileUploader.Upload(command.Picture, slug);

            articaleCategory.Edit(command.Name, command.Description,command.ShortDescription,
                                                   pictureName, command.ShowOrder,
                                                   command.CanonicalAddress, command.KeyWords,
                                                   command.MetaDescription, slug);

            _articleCategoryRepository.Save();

            return opration.Succedded();
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _articleCategoryRepository.Details(id);
        }

        public List<ArticleCategoryViewModel> Search(SearchArticleCategory searchModel)
        {
            return _articleCategoryRepository.Search(searchModel);
        }

    }
}
