using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Models
{
    public class MonthlyLedger
    {
        public MonthlyLedger()
        {
                
        }
        public short Year { get; set; }
        public sbyte Month { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Total { get; set; }
    }
}
