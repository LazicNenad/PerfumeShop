using FluentValidation;
using PerfumeShop.Application.DTO.Milliliters;
using PerfumeShop.Application.Exceptions;
using PerfumeShop.Application.UseCases.Commands.MilliliterCommands;
using PerfumeShop.DataAccess;
using PerfumeShop.Implementation.Validations.MilliliterValidations;

namespace PerfumeShop.Implementation.UseCases.Commands.EF.Milliliters;

public class EfUpdateMilliliterCommand : EfUseCase, IUpdateMilliliterCommand
{
    private readonly UpdateMilliliterValidation _validator;
    public EfUpdateMilliliterCommand(PerfumeContext context, UpdateMilliliterValidation validator) : base(context)
    {
        _validator = validator;
    }

    public void Execute(MilliliterDto request)
    {
        _validator.ValidateAndThrow(request);

        var milliliter = Context.Milliliters.Find(request.Id);

        if (milliliter == null)
        {
            throw new NotFountException($"Milliliter with id {request.Id} doesn't exist in our system.");
        }

        milliliter.Capacity = request.Capacity;

        Context.SaveChanges();
    }

    public int Id => 16;
    public string Name => "Update Milliliter Command";
    public string Description => "EntityFramework update milliliters";
}