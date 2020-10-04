using AppShop.Application.Common.Interfaces;
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
   public class GetProdCatQuery : IRequest<List<ProductCategoryEntity>>
    {
    }

    public class GetProdCatQueryHandler : IRequestHandler<GetProdCatQuery, List<ProductCategoryEntity>>
    {

        private readonly IAppDbContext _context;


        public GetProdCatQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductCategoryEntity>> Handle(GetProdCatQuery request, CancellationToken cancellationToken)
        {

            List<ProductCategoryEntity> ProductEntity = await _context.ProductCategory.ToListAsync();

            return ProductEntity;
        }

       
    }
}
