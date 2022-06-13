using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Domain.Entities
{
    public class OrderLine : Entity
    {
        public int OrderId { get; set; }
        public int PerfumeId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public ushort MilliliterCapacity { get; set; }
        public decimal Price { get; set; }
        
        public virtual Order Order { get; set; }
        public virtual Perfume Perfume { get; set; }

    }
}
