using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Models
{
    public class BaseEntity
    {
        public bool? Status { get; set; } = true;

        public Guid ID { get; set; } = Guid.NewGuid();
    }
}
