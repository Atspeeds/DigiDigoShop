using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DigiDigoQuery.Contract.Invantory
{
    public class InvantoryQueryModel
    {
        public long ProductId { get; set; }
        public double UnitPrice { get; set; }
        public bool Stock { get; set; }
    }
}
