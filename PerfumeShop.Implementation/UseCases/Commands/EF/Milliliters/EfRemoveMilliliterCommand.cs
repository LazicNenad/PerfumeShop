using FluentValidation;
using PerfumeShop.Application.Exceptions;
using PerfumeShop.Application.UseCases.Commands.MilliliterCommands;
using PerfumeShop.DataAccess;
using PerfumeShop.DataAccess.Extensions;
using PerfumeShop.Implementation.Validations.MilliliterValidations;

namespace PerfumeShop.Implementation.UseCases.Commands.EF.Milliliters;

public class EfRemoveMilliliterCommand : EfUseCase, IRemoveMilliliterCommand
{
    private readonly RemoveMilliliterValidation _validator;
    public EfRemoveMilliliterCommand(PerfumeContext context, RemoveMilliliterValidation validator) : base(context)
    {
        _validator = validator;
    }

    public void Execute(int request)
    {
        _validator.ValidateAndThrow(request);

        var milliliterToDelete = Context.Milliliters.Find(request);

        if (milliliterToDelete == null)
        {
            throw new NotFountException($"Milliliter with id {request} was not found in our system");
        }

        Context.SoftDeleteEntity(milliliterToDelete);

        Context.SaveChanges();
    }

    public int Id => 17;
    public string Name => "Delete milliliter from system";
    public string Description => "Delete milliliter from system using EntityFramework";
}