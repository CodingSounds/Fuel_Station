using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel_Station.Shared
{
    public class CustomerViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public bool Status { get; set; } // = true;??

        public Guid ID { get; set; }
       
        public string CardNumber { get; set; }
    }
}
