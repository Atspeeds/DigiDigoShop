using _0_FrameWork.Domain;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : EntitySeo
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ShortDescription { get; private set; }
        public string Picture { get; private set; }
        public int ShowOrder { get; private set; }
        public string CanonicalAddress { get; private set; }


        #region Add || Edit
        public ArticleCategory(string name, string description, string shortDescription,
            string picture, int showOrder, string canonicalAddress,
            string keyWords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            ShortDescription = shortDescription;
            Picture = picture;
            ShowOrder = showOrder;
            CanonicalAddress = canonicalAddress;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;

        }

        public void Edit(string name, string description,string shortDescription,
           string picture, int showOrder, string canonicalAddress,
           string keyWords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            ShortDescription = shortDescription;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            ShowOrder = showOrder;
            CanonicalAddress = canonicalAddress;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        #endregion


    }
}
