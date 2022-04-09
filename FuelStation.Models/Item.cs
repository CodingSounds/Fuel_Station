using FuelStation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Models
{
    public class Item:BaseEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public ItemTypeEnum ItemType { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }

        //EntityFramework Properties
        public List<TransactionLine> TransactionLineList { get; set; }

    }
}
