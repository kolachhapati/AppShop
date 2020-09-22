using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppShop.Application.Product.Commands.CreateProduct;
using AppShop.Application.Product.Queries.GetProducts;
using AppShop.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<List<ProductEntity>>> Get()
        {
            return await Mediator.Send(new GetProductsQuery());
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<int>> Create(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
