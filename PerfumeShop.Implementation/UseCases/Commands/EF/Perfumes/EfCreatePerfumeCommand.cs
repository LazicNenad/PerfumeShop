using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PerfumeShop.Application.DTO.Perfumes;
using PerfumeShop.Application.UseCases.Commands.PerfumeCommands;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain.Entities;
using PerfumeShop.Implementation.Validations.PerfumeValidations;

namespace PerfumeShop.Implementation.UseCases.Commands.EF.Perfumes
{
    public class EfCreatePerfumeCommand : EfUseCase, ICreatePerfumeCommand
    {
        private readonly CreatePerfumeValidation _validator;
        public EfCreatePerfumeCommand(PerfumeContext context, CreatePerfumeValidation validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 11;
        public string Name => "Create Perfume";
        public string Description => "EntityFramework Create Perfume";

        public void Execute(CreateUpdatePerfumeDto request)
        {
            _validator.ValidateAndThrow(request);

            var perfume = new Perfume()
            {
                Name = request.Name,
                Description = request.Description,
                BrandId = request.BrandId,
                CategoryId = request.CategoryId
            };

            var productTypeValues = request.ProductTypeIds.Select(x => new PerfumeProductType()
            {
                Perfume = perfume,
                ProductTypeId = x
            });

            var perfumeMilliliterValues = request.MilliliterIds.Select(x => new PerfumeMilliliter()
            {
                Perfume = perfume,
                MilliliterId = x
            });

            Context.Perfumes.Add(perfume);
            Context.PerfumeProductTypes.AddRange(productTypeValues);
            Context.PerfumeMilliliters.AddRange(perfumeMilliliterValues);

            Context.SaveChanges();
        }
    }
}
