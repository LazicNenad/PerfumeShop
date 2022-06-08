using PerfumeShop.Application.UseCases.DTO.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Application.UseCases.Commands.BrandCommands
{
    public interface IDeleteBrand : ICommand<int>
    {
    }
}
