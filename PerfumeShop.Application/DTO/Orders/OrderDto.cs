using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.DTO.PerfumeMilliliter;
using PerfumeShop.Application.UseCases.DTO;

namespace PerfumeShop.Application.DTO.Orders
{
    public class OrderDto : BaseDto
    {
        public int UserId { get; set; }
        public IEnumerable<PerfumeMilliliterDto> PerfumeMilliliterIds { get; set; } = new List<PerfumeMilliliterDto>();
    }
}
