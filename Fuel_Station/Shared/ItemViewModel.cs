using FuelStation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel_Station.Shared
{
    public class ItemViewModel
    {
        public Guid ID { get; set; }
        
        public bool Status { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public ItemTypeEnum ItemType { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
}
