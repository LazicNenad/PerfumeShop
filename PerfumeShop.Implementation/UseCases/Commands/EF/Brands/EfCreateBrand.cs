using FluentValidation;
using PerfumeShop.Application.UseCases.Commands.BrandCommands;
using PerfumeShop.Application.UseCases.DTO.Brands;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain.Entities;
using PerfumeShop.Implementation.Validations.BrandValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.UseCases.Commands.EF.Brands
{
    public class EfCreateBrand : EfUseCase, ICreateBrand
    {
        private readonly CreateBrandValidation _validation;
        public EfCreateBrand(PerfumeContext context, CreateBrandValidation validation) : base(context)
        {
            _validation = validation;
        }

        public int Id => 5;

        public string Name => "Create Brand";

        public string Description => "EntityFramework Creating Brand";

        public void Execute(BrandDto request)
        {
            _validation.ValidateAndThrow(request);

            var brand = new Brand
            {
                BrandName = request.Name
            };

            Context.Brands.Add(brand);

            Context.SaveChanges();
        }
    }
}
