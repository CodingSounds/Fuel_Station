using FuelStation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Models
{
    public class Employee:Person
    {
      
        public DateTime HireDateStart { get; set; }= DateTime.Now;//otan ton ftiaxno xekina ti doulia
        public DateTime? HireDateEnd { get; set; }//otan ginete to active=false to stamatao SOS

        public decimal SalaryPerMonth { get; set; }
        
        public EmployeeTypeEnum EmployeeType { get; set; }

        //EntityFrameWork properties are in Person

        //Login Properties

        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
