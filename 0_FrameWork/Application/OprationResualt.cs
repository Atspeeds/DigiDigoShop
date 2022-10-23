namespace _0_FrameWork.Application
{
    public class OprationResualt
    {
        public OprationResualt()
        {
            IsSuccedded = false;
        }

        public string Message { get; set; }
        public bool IsSuccedded { get; set; }

        public OprationResualt Succedded(string message = "عملیات با موفقیت انجام شد.")
        {
            Message = message;
            IsSuccedded = true;
            return this;
        }

        public OprationResualt Failed(string message)
        {
            Message = message;
            IsSuccedded = false;
            return this;
        }
    }
}
