using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel_Station.Shared
{
    public class TransactionLineViewModel
    {
        public Guid ID { get; set; }
        public Guid TransactionID { get; set; }
        public Guid ItemID { get; set; }//xreiazetai?

        public string ItemCode { get; set; }
        public decimal? Quantity { get; set; }//Sigoura to thelo decimal logo kausimon?
        public decimal ItemPrice { get; set; }
        public decimal NetValue { get; set; }
        public decimal DiscountPercent { get; set; }//thelei validetion mallon apo edo
        public decimal DiscountValue { get; set; }
        public decimal TotalValueOfLine { get; set; }
    }
}
