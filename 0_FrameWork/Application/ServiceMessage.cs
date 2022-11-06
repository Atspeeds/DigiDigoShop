namespace _0_FrameWork.Application
{
    public class ServiceMessage
    {
        public string Successful { get; set; }

        public static string DuplicateField = ".فیلد تکراری است لطفا مجدد تلاش کنید ";

        public static string EmptyRecord = ".رکوردی با این آیدی پیدا نشد لطفا مجدد تلاش کنید";

        public const string IsRequired = "این مقدار نمی تواند خالی باشد";

        public const string MaxFileSize = "فایل حجیم تر از حد مجاز است";

        public const string InvalidFileFormat = "فرمت فایل مجاز نیست";

        public const string MaxLenght = "مقدار وارد شده بیش از طول مجاز است";
    }
}
