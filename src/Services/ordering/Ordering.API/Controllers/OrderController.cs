using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Order.Command.CheckoutOrder;
using Ordering.Application.Features.Order.Command.DeleteOrder;
using Ordering.Application.Features.Order.Command.UpdateOrder;
using Ordering.Application.Features.Order.Query.GetOrderList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ordering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/api/getorder/{userName}")]
        [ProducesResponseType(typeof(IEnumerable<OrderVm>) , (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrderByUserName(string userName)
        {
            var query = new GetOrderList(userName);

            var order = await _mediator.Send(query);
            return Ok(order);
        }

        [HttpPost]
        [Route("/api/CheckoutOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CheckoutOrder([FromBody]CheckoutOrderCommand vm)
        {
            var res = await _mediator.Send(vm);
            return Ok(res);
        }

        [HttpPost]
        [Route("/api/UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CheckoutOrder([FromBody] UpdateOrderCommand vm)
        {
            await _mediator.Send(vm);
            return NoContent();
        }
        [HttpPost]
        [Route("/api/DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CheckoutOrder(int id)
        {
            var command = new DeleteOrderCommand()
            {
                Id = id
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
