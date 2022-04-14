using FuelStation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel_Station.Shared
{
    public class EmployeeViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }    
        public string Surname { get; set; }
        public bool Status { get; set; }

        public DateTime HireDateStart { get; set; } = DateTime.Now;//otan ton ftiaxno xekina ti doulia
        public DateTime? HireDateEnd { get; set; }//otan ginete to active=false to stamatao SOS

        public decimal SalaryPerMonth { get; set; }

        public EmployeeTypeEnum EmployeeType { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
