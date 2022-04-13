using FuelStation.Models;
using FuelStation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel_Station.Shared
{
    public class TransactionViewModel
    {
        //status NO?
        public Guid ID { get; set; }
        public DateTime Date { get; set; } 
        public Guid EmployeeID { get; set; }
        public Guid CustomerID { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }

        public string CardNumber { get; set; }
        public string EmployeeType { get; set; }
        public decimal TotalValue { get; set; }


        public List<TransactionLineViewModel> TransactionLinesList { get; set; }
    }

    public class TransactionCreateViewModel
    {
        //status NO?
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public Guid EmployeeID { get; set; }
        public Guid CustomerID { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public decimal TotalValue { get; set; }




        public List<TransactionLineViewModel> TransactionLinesList { get; set; }
    }
}
