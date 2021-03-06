using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Domain.Entities
{
    public class Category : Entity
    {
        public string CategoryName { get; set; }

        public virtual ICollection<Perfume> Perfumes { get; set; } = new List<Perfume>();
    }
}
