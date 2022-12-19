namespace DisCountManagement.Application.Contract.CustomerDisCount
{
    public class CustomerDisCountSearchModel
    {
        public long ProductId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
