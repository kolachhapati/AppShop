using AppShop.Application.Common.Interfaces;
using AppShop.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppShop.Application.Product.Queries.GetProducts
{
    public class GetProductsByIdQuery : IRequest<List<ProductEntity>>
    {
        public int ProductCategoryId;
    }

    public class GetProductsByIdQueryHandler : IRequestHandler<GetProductsByIdQuery, List<ProductEntity>>
    {

        private readonly IAppDbContext _context;


        public GetProductsByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductEntity>> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
        {
            List<ProductCategoryEntity> prodcategories = await _context.ProductCategory.ToListAsync();

            var category = prodcategories.Find(x => x.ProductCategoryId == request.ProductCategoryId);
            List<ProductEntity> ProductEntity = await _context.Products.Where(x => x.ProductCategory == category).ToListAsync();
            
            return ProductEntity;
        }
    }
}
