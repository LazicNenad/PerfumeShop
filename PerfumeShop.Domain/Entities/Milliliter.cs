using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Domain.Entities
{
    public class Milliliter : Entity
    {
        public ushort Capacity { get; set; }

        public virtual ICollection<PerfumeMilliliter> PerfumeMilliliters { get; set; } = new List<PerfumeMilliliter>();
    }
}
