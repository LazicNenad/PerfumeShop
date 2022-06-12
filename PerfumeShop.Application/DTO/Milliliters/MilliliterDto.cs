using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.UseCases.DTO;

namespace PerfumeShop.Application.DTO.Milliliters
{
    public class MilliliterDto : BaseDto
    {
        public ushort Capacity { get; set; }
    }
}
