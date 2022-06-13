using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Domain.Entities
{
    public class Order : Entity
    {
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
