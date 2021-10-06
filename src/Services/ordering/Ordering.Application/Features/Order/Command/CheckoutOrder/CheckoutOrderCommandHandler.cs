using Mapster;
using MediatR;
using Ordering.Application.Contracts.Infrastracture;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Ordering.Application.Features.Order.Command.CheckoutOrder
{
    class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
    {
        private readonly IOrderRepo _repo;
        private readonly IEmailRepo _email;

        public CheckoutOrderCommandHandler(IOrderRepo repo, IEmailRepo email)
        {
            _repo = repo;
            _email = email;
        }

        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {

            var order = request.Adapt<Ordring.Domain.Entities.Order>();

            var newOrder = await _repo.Add(order);

            await SendEmail(newOrder);

            return newOrder.Id;
        }
        private async Task SendEmail(Ordring.Domain.Entities.Order order)
        {
            var email = new Email() { Body = "Order was created", Subject = "I am a subject", To = "Mohamad1382mhd@gmail.com" };

            try
            {
                await _email.SendEmail(email);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }
    }
}
