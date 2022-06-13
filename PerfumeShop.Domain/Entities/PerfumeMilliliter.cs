using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Domain.Entities
{
    public class PerfumeMilliliter
    {
        public int PerfumeId { get; set; }
        public int MilliliterId { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Perfume Perfume { get; set; }
        public virtual Milliliter Milliliter { get; set; }
    }
}
