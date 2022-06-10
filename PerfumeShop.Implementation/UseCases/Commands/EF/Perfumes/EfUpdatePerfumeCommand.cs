using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PerfumeShop.Application.DTO.Perfumes;
using PerfumeShop.Application.Exceptions;
using PerfumeShop.Application.UseCases.Commands.PerfumeCommands;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain.Entities;
using PerfumeShop.Implementation.Validations.PerfumeValidations;

namespace PerfumeShop.Implementation.UseCases.Commands.EF.Perfumes
{
    public class EfUpdatePerfumeCommand : EfUseCase, IUpdatePerfumeCommand
    {
        private UpdatePerfumeValidation _validator;
        public EfUpdatePerfumeCommand(PerfumeContext context, UpdatePerfumeValidation validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 13;
        public string Name => "Update Perfume";
        public string Description => "EntityFramework update perfume";
        public void Execute(CreateUpdatePerfumeDto request)
        {
            _validator.ValidateAndThrow(request);

            var perfume = Context.Perfumes.Find(request.Id);

            if (perfume == null)
            {
                throw new NotFountException($"Perfume with {request.Id} not found in our system. From UpdatePerfumeCommand");
            }

            perfume.Name = request.Name;
            perfume.Description = request.Description;
            perfume.BrandId = request.BrandId;
            perfume.CategoryId = request.CategoryId;

            var productTypes = Context.PerfumeProductTypes.Where(x => x.PerfumeId == request.Id).ToList();
            var milliliters = Context.PerfumeMilliliters.Where(x => x.PerfumeId == request.Id).ToList();

            Context.PerfumeProductTypes.RemoveRange(productTypes);
            Context.PerfumeMilliliters.RemoveRange(milliliters);

            var newProductType = request.ProductTypeIds.Select(x => new PerfumeProductType()
            {
                Perfume = perfume,
                ProductTypeId = x
            });

            var newMilliliters = request.MilliliterIds.Select(x => new PerfumeMilliliter()
            {
                Perfume = perfume,
                MilliliterId = x
            });

            Context.PerfumeProductTypes.AddRange(newProductType);
            Context.PerfumeMilliliters.AddRange(newMilliliters);
            Context.SaveChanges();
        }
    }
}
