using FuelStation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Models
{
    public class Transaction:BaseEntity
    {
        
        public DateTime Date { get; set; }= DateTime.Now;//sigoura na ginete
        public Guid EmployeeID { get; set; }
        public Guid CustomerID { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }

        public decimal TotalValue { get; set; }



        //EntityFrameWork Properties
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public List<TransactionLine> TransactionLinesList { get; set; }
    }
}
