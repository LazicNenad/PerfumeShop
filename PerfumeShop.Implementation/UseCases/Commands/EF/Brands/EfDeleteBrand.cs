using FluentValidation;
using PerfumeShop.Application.UseCases.Commands.BrandCommands;
using PerfumeShop.Application.UseCases.DTO.Brands;
using PerfumeShop.DataAccess;
using PerfumeShop.DataAccess.Extensions;
using PerfumeShop.Implementation.Validations.BrandValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.Exceptions;

namespace PerfumeShop.Implementation.UseCases.Commands.EF.Brands
{
    public class EfDeleteBrand : EfUseCase, IDeleteBrand
    {
        private readonly DeleteBrandValidation _validation;
        public EfDeleteBrand(PerfumeContext context, DeleteBrandValidation validation) : base(context)
        {
            _validation = validation;
        }

        public int Id => 4;

        public string Name => "Delete brand";

        public string Description => "Soft delete brand using EF";

        public void Execute(int request)
        {
            _validation.ValidateAndThrow(request);

            var brandToDelete = Context.Brands.Find(request);

            if (brandToDelete == null)
            {
                throw new NotFountException($"Brand with id {request} was not found in our system.");
            }

            Context.SoftDeleteEntity(brandToDelete);

            Context.SaveChanges();
        }
    }
}
