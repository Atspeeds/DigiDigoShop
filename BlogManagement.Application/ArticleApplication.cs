using _0_FrameWork.Application;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using System.Collections.Generic;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        private readonly IArticleCategoryRepository _articleCategoryRepository;

        private readonly IFileUploader _fileUploader;

        public ArticleApplication(IArticleRepository articleRepository, IFileUploader fileUploader)
        {
            _articleRepository = articleRepository;
            _fileUploader = fileUploader;
        }

        public OprationResualt Add(CreateArticle command)
        {
            OprationResualt opration = new OprationResualt();

            if (_articleRepository.Exists(x => x.Title == command.Title))
                return opration.Failed(ServiceMessage.DuplicateField);

            var caregorySlug = _articleCategoryRepository.GetSlug(command.CategoryId);

            var slug = command.Slug.Slugify();

            var fileName = _fileUploader.Upload(command.Picture, $"{caregorySlug}/{slug}");

            var article = new Article(command.Title, command.Description, command.ShortDescription,
                command.DateRelease, fileName, command.PictureAlt, command.PictureTitle,
                command.CanonicalAddress, command.CategoryId, command.KeyWords,
                command.MetaDescription, slug);

            _articleRepository.Save();

            return opration.Succedded();
        }

        public OprationResualt Edit(EditArticle command)
        {
            OprationResualt opration = new OprationResualt();

            if (_articleRepository.Exists(x => x.Title == command.Title && x.KeyId != command.Id))
                return opration.Failed(ServiceMessage.DuplicateField);

            var article = _articleRepository.Get(command.Id);

            if (article is null) return opration.Failed(ServiceMessage.EmptyRecord);


            var caregorySlug = _articleCategoryRepository.GetSlug(command.CategoryId);

            var slug = command.Slug.Slugify();

            var fileName = _fileUploader.Upload(command.Picture, $"{caregorySlug}/{slug}");

            article.Edit(command.Title, command.Description, command.ShortDescription,
              command.DateRelease, fileName, command.PictureAlt, command.PictureTitle,
              command.CanonicalAddress, command.CategoryId, command.KeyWords,
              command.MetaDescription, slug);

            _articleRepository.Save();

            return opration.Succedded();
        }

        public EditArticle GetDetails(long id)
        {
            return _articleRepository.Details(id);
        }

        public List<ArticleViewModel> Search(SearchArticle searchModel)
        {
            return _articleRepository.Search(searchModel);
        }

    }
}
