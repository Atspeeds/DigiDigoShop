using _0_FrameWork.Domain;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;

namespace BlogManagement.Domain.ArticleAgg
{
    public class Article : EntitySeo
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ShortDescription { get; private set; }
        public DateTime DateRelease { get; private set; }
        public string Author { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string CanonicalAddress { get; private set; }
        public long CategoryId { get; private set; }


        //RelationShip

        //To ArticleCategory
        public ArticleCategory ArticleCategory { get; private set; }





        #region Constractor Add || Edit || Delete

  

        public Article(string title, string description, string shortDescription,
            DateTime dateRelease, string picture, string pictureAlt,
            string pictureTitle, string canonicalAddress, long categoryId,
            string keyWords,string metaDescription,string slug)
        {
            Title = title;
            Description = description;
            ShortDescription = shortDescription;
            DateRelease = dateRelease;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
            KeyWords = keyWords;
            MetaDescription= metaDescription;
            Slug = slug;
        }


        public void Edit(string title, string description, string shortDescription,
           DateTime dateRelease, string picture, string pictureAlt,
           string pictureTitle, string canonicalAddress, long categoryId,
            string keyWords, string metaDescription, string slug)
        {
            Title = title;
            Description = description;
            ShortDescription = shortDescription;
            DateRelease = dateRelease;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
        }




        #endregion

    }
}
