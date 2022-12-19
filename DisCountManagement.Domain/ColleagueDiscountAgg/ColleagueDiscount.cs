using _0_FrameWork.Domain;

namespace DisCountManagement.Domain.ColleagueDiscountAgg
{
    public class ColleagueDiscount : EntityBase
    {
        public long ProductId { get; private set; }
        public int DisCountRate { get; private set; }
        public bool IsRemove { get; private set; }


        #region Constroctor Add || Edit || Remove || Restore
        public ColleagueDiscount(long productId, int disCountRate)
        {
            ProductId = productId;
            DisCountRate = disCountRate;
            IsRemove = false;
        }
        public void Edit(long productId, int disCountRate)
        {
            ProductId = productId;
            DisCountRate = disCountRate;
        }

        public void Removed()
        {
            IsRemove = true;
        }
        public void Restore()
        {
            IsRemove = false;
        }
        #endregion

    }
}
