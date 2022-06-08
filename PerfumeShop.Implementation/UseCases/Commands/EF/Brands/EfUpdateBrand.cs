using FluentValidation;
using PerfumeShop.Application.UseCases.Commands.BrandCommands;
using PerfumeShop.Application.UseCases.DTO.Brands;
using PerfumeShop.DataAccess;
using PerfumeShop.Implementation.Validations.BrandValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.UseCases.Commands.EF.Brands
{
    public class EfUpdateBrand : EfUseCase, IUpdateBrand
    {
        private readonly UpdateBrandValidation _validation;
        public EfUpdateBrand(PerfumeContext context, UpdateBrandValidation validation) : base(context)
        {
            _validation = validation;
        }

        public int Id => 3;

        public string Name => "Update Brand Name";

        public string Description => "Update brand name using EntityFramework";

        public void Execute(BrandDto request)
        {
            _validation.ValidateAndThrow(request);

            var brandToUpdate = Context.Brands.Find(request.Id);

            brandToUpdate.BrandName = request.Name;

            Context.SaveChanges();
        }
    }
}
