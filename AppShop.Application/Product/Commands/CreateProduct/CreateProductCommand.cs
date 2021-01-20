using AppShop.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading;
using AppShop.Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AppShop.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateProductCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //INSTEAD OF ProductEntity CREATE NEW PRODUCT ENTITY DTO OBJECT
            ProductCategoryEntity category = _context.ProductCategory.Where(x => x.ProductCategoryId == request.ProductCategoryId).SingleOrDefault();

            var entity = new ProductEntity
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                ProductCategory = category
            };

            _context.Products.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.ProductId;
        }
    }
}
