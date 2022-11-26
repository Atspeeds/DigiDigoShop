namespace ShopManagement.Application.Contract.ProductPicture
{
    public class ProductPictureViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string DataTime { get; set; }
        public bool IsRemoved { get; set; }
    }

}
