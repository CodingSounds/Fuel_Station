using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Models
{
    public class Customer:Person
    {
      
        public string CardNumber { get; set; }//has validation

        //EntityFrameWork properties are in Person
    }
}
