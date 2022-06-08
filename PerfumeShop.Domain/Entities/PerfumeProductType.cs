using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Domain.Entities
{
    public class PerfumeProductType
    {
        public int PerfumeId { get; set; }
        public int ProductTypeId { get; set; }

        public virtual Perfume Perfume { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
