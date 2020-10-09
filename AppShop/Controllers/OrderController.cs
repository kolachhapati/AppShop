using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppShop.Application.Order.Commands.CreateOrder;
using AppShop.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<OrderVmlList>> Create(CreateOrderCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        [Route("Complete")]
        public async Task<ActionResult<string>> Create(CreateSalesCommand command)
        {
            return await Mediator.Send(command);
        }

    }
}
