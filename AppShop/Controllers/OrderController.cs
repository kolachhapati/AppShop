﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppShop.Application.Order.Commands.CreateOrder;
using AppShop.Application.Order.Queries.GetOrder;
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

        [HttpGet]
        [Route("GetOrderList")]
        public async Task<ActionResult<List<GetSalesVm>>> GetSales()
        {
            return await Mediator.Send(new GetOrderQuery());
        }

        [HttpPost]
        [Route("Complete")]
        public async Task<ActionResult<string>> Complete(CreateSalesCommand command)
        {
            return await Mediator.Send(command);
        }

    }
}
