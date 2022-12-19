namespace DisCountManagement.Application.Contract.ColleagueDiscount
{
    public class ColleagueDisCountViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public int DisCountRate { get; set; }
        public bool IsRemoved { get; set; }
        public string CreationDate { get; set; }
      
    }

}
