using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Models
{
    public class Person:BaseEntity
    {
      
        public string Name { get; set; }
        public string Surname { get; set; }


        //EntityFrameWork
        public List<Transaction> TransactionList { get; set; }
    }
}
