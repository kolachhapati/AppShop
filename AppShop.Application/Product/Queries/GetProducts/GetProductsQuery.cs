using AppShop.Application.Common.Interfaces;
using AppShop.Application.Product.Queries.ViewModel;
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
    public class GetProductsQuery : IRequest<List<ProductVm>>
    {
    }
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductVm>>
    {

        private readonly IAppDbContext _context;


        public GetProductsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductVm>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            List<ProductVm> products = await (from p in _context.Products
                                              join c in _context.ProductCategory on p.ProductCategoryId equals c.ProductCategoryId
                                              select new ProductVm()
                                              {
                                                  Name = p.Name,
                                                  Description = p.Description,
                                                  Price = p.Price,
                                                  Category = c.Name
                                              }).OrderBy(x => x.Category).ToListAsync();

            return products;
        }
    }
}
