using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PerfumeShop.Application.DTO.Orders;
using PerfumeShop.Application.UseCases.Commands.OrderCommands;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain.Entities;
using PerfumeShop.Implementation.Validations.OrderValidations;

namespace PerfumeShop.Implementation.UseCases.Commands.EF.Orders
{
    public class EfCreateOrderCommand : EfUseCase, ICreateOrderCommand
    {
        private readonly OrderValidation _validator;
        public EfCreateOrderCommand(PerfumeContext context, OrderValidation validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 19;
        public string Name => "Create Order command";
        public string Description => "CreateOrderCommand EntityFramework";

        public void Execute(OrderDto request)
        {
            _validator.ValidateAndThrow(request);

            var order = new Order()
            {
                UserId = request.UserId,
                OrderDate = DateTime.UtcNow
            };

            var orderLine = request.PerfumeMilliliterIds.Select(x => new OrderLine()
            {
                Name = Context.Perfumes.Find(x.PerfumeId).Name,
                Order = order,
                PerfumeId = x.PerfumeId,
                MilliliterCapacity = Context.Milliliters.Find(x.MilliliterId).Capacity,
                Quantity = x.Quantity,
                Price = (x.UnitPrice * x.Quantity)
            });

            Context.Orders.Add(order);
            Context.OrderLines.AddRange(orderLine);

            Context.SaveChanges();

        }


    }
}
