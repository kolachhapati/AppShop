using AppShop.Application.Common.Interfaces;
using AppShop.Application.Product.Queries.ViewModel;
using AppShop.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppShop.Application.Product.Queries.GetProducts
{
   public class GetProductsQuery : IRequest<List<ProductEntity>>
    {
    }
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductEntity>>
    {

        private readonly IAppDbContext _context;
       

        public GetProductsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductEntity>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {

            List<ProductEntity> ProductEntity = await _context.Products.ToListAsync();

            return ProductEntity;
        }
    }
}
