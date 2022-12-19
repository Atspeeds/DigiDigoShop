using System;
using System.Security.Principal;

namespace DisCountManagement.Application.Contract.CustomerDisCount
{
    public class CustomerDisCountViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public DateTime StartDateGr { get; set; }
        public DateTime EndDateGr { get; set; }
        public string DateCreation { get; set; }
        public int DisCountRate { get; set; }
        public string Reason { get; set; }
    }

}
