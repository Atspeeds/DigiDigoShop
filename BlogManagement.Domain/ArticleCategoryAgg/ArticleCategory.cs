using _0_FrameWork.Domain;
using BlogManagement.Domain.ArticleAgg;
using System.Collections.Generic;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : EntitySeo
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ShortDescription { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public int ShowOrder { get; private set; }
        public string CanonicalAddress { get; private set; }




        //RelationShip

        //To ArticleCategory
        public List<Article> Article { get; private set; }


        #region Add || Edit
        public ArticleCategory(string name, string description, string shortDescription,
            string picture, string pictureAlt, string pictureTitle, int showOrder, string canonicalAddress,
            string keyWords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            ShortDescription = shortDescription;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShowOrder = showOrder;
            CanonicalAddress = canonicalAddress;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;

        }

        public void Edit(string name, string description, string shortDescription,
           string picture, string pictureAlt, string pictureTitle, int showOrder, string canonicalAddress,
           string keyWords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            ShortDescription = shortDescription;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            ShowOrder = showOrder;
            CanonicalAddress = canonicalAddress;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        #endregion


    }
}
