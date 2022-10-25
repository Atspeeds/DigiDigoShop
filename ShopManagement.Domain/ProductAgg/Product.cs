﻿using _0_FrameWork.Domain;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsInStock { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public long CategoryId { get; private set; }

        //RelationShip

        //To ProductCategory
        public ProductCategory Category { get; private set; }


        #region Constractor Add || Edit || Delete

        public Product(string name, string code, string shortDescription, string description,
           string picture, string pictureAlt, string pictureTitle, long categoryId, string slug,
           string keywords, string metaDescription,double unitprice)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Slug = slug;
            KeyWords = keywords;
            MetaDescription = metaDescription;
            UnitPrice = unitprice;
        }

        public void Edit(string name, string code, string shortDescription, string description, string picture,
          string pictureAlt, string pictureTitle, long categoryId, string slug,
          string keywords, string metaDescription,double unitprice)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Slug = slug;
            KeyWords = keywords;
            MetaDescription = metaDescription;
            UnitPrice = unitprice;
        }

        public void InStock()
        {
            IsInStock = true;
        }

        public void NotInStock()
        {
            IsInStock = false;
        }

        #endregion



    }
}
