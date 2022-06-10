using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.UseCases.DTO;

namespace PerfumeShop.Application.DTO.Perfumes
{
    public class CreateUpdatePerfumeDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<int> ProductTypeIds { get; set; } = new List<int>();
        public IEnumerable<int> MilliliterIds { get; set; } = new List<int>();
    }
}
