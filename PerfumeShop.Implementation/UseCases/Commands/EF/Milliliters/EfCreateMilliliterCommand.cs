using FluentValidation;
using PerfumeShop.Application.DTO.Milliliters;
using PerfumeShop.Application.UseCases.Commands.MilliliterCommands;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain.Entities;
using PerfumeShop.Implementation.Validations.MilliliterValidations;

namespace PerfumeShop.Implementation.UseCases.Commands.EF.Milliliters;

public class EfCreateMilliliterCommand : EfUseCase, ICreateMilliliterCommand
{
    private readonly CreateMilliliterValidation _validator;
    public EfCreateMilliliterCommand(PerfumeContext context, CreateMilliliterValidation validator) : base(context)
    {
        _validator = validator;
    }
    public void Execute(MilliliterDto request)
    {
        _validator.ValidateAndThrow(request);

        var milliliter = new Milliliter()
        {
            Capacity = request.Capacity
        };

        Context.Milliliters.Add(milliliter);

        Context.SaveChanges();
    }

    public int Id => 15;
    public string Name => "Create Milliliter";
    public string Description => "EntityFramework Create Milliliters";


}