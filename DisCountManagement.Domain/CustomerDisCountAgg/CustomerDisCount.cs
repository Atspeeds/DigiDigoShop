using _0_FrameWork.Domain;
using System;

namespace DisCountManagement.Domain.CustomerDisCountAgg
{
    public class CustomerDisCount : EntityBase
    {
        public long ProductId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int DisCountRate { get; private set; }
        public string Reason { get; private set; }




        #region Constroctor Add || Edit 
        public CustomerDisCount(long productId, DateTime startDate, DateTime endDate,
            int disCountRate, string reason)
        {
            ProductId = productId;
            StartDate = startDate;
            EndDate = endDate;
            DisCountRate = disCountRate;
            Reason = reason;
        }

        public void Edit(long productId, DateTime startDate, DateTime endDate,
            int disCountRate, string reason)
        {
            ProductId = productId;
            StartDate = startDate;
            EndDate = endDate;
            DisCountRate = disCountRate;
            Reason = reason;
        }


        #endregion

    }
}
