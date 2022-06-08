using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Domain.Entities
{
    public class Perfume : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
        public virtual ICollection<PerfumeProductType> PerfumeProductTypes { get; set; } = new List<PerfumeProductType>();
        public virtual ICollection<PerfumeMilliliter> PerfumeMilliliters { get; set; } = new List<PerfumeMilliliter>();
    }
}
