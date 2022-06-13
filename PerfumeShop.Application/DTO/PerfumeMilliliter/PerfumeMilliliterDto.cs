using PerfumeShop.Application.UseCases.DTO;

namespace PerfumeShop.Application.DTO.PerfumeMilliliter
{
    public class PerfumeMilliliterDto : BaseDto
    {
        public int PerfumeId { get; set; }
        public int MilliliterId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
