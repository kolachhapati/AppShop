﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppShop.Application.Product.Commands.CreateProduct;
using AppShop.Application.Product.Commands.DeleteProduct;
using AppShop.Application.Product.Queries.GetProducts;
using AppShop.Application.Product.Queries.ViewModel;
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
        public async Task<ActionResult<List<ProductVm>>> Get()
        {
            return await Mediator.Send(new GetProductsQuery());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<List<ProductEntity>>> GetById(int id)
        {
            return await Mediator.Send(new GetProductsByIdQuery { ProductCategoryId = id });
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<int>> Create(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        [Route("CreateProdCat")]
        public async Task<ActionResult<int>> Create(CreateProductCategoryCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        [Route("GetCat")]
        public async Task<ActionResult<List<ProductCategoryEntity>>> GetCat()
        {
            return await Mediator.Send(new GetProdCatQuery());
        }

        [HttpDelete]
        [Route("DelProduct")]
        public async Task<ActionResult<string>> DeleteProduct(int id)
        {
            return await Mediator.Send(new DeleteProductCommand { Id = id });
        }

        [HttpDelete]
        [Route("DelProdCat")]
        public async Task<ActionResult<string>> DeleteProductCategory(int id)
        {
            return await Mediator.Send(new DeleteProductCategoryCommand { Id = id });
        }
    }
}
