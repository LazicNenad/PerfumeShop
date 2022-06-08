using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Domain.Entities
{
    public class ProductType : Entity
    {
        public string Type { get; set; }

        public virtual ICollection<PerfumeProductType> PerfumeTypes { get; set; } = new List<PerfumeProductType>();
    }
}
