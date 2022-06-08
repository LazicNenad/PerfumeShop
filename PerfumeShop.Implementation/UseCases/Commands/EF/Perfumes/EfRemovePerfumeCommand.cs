using PerfumeShop.Application.Exceptions;
using PerfumeShop.Application.UseCases.Commands.PerfumeCommands;
using PerfumeShop.DataAccess;
using PerfumeShop.DataAccess.Extensions;

namespace PerfumeShop.Implementation.UseCases.Commands.EF.Perfumes;

public class EfRemovePerfumeCommand : EfUseCase, IRemovePerfumeCommand
{
    public EfRemovePerfumeCommand(PerfumeContext context) : base(context)
    {
    }

    public int Id => 12;
    public string Name => "Delete Perfume";
    public string Description => "EntityFramework Delete perfume with his relations.";

    public void Execute(int request)
    {
        var perfume = Context.Perfumes.Find(request);

        if (perfume == null)
        {
            throw new NotFountException($"Perfume with {request} id is not found in our system");
        }

        var perfumeProductTypes = Context.PerfumeProductTypes.Where(x => x.PerfumeId == perfume.Id).ToList();
        var perfumeMilliliters = Context.PerfumeMilliliters.Where(x => x.PerfumeId == perfume.Id).ToList();

        Context.PerfumeProductTypes.RemoveRange(perfumeProductTypes);
        Context.PerfumeMilliliters.RemoveRange(perfumeMilliliters);
        Context.SoftDeleteEntity(perfume);

        Context.SaveChanges();
    }
}