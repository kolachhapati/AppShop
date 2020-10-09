using AppShop.Application.Common.Interfaces;
using AppShop.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppShop.Application.Product.Commands.CreateProduct
{
    public class CreateProductCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateProductCategoryCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            //INSTEAD OF ProductCategoryEntity CREATE NEW DTO OBJECT
            var entity = new ProductCategoryEntity   
            {
                Name = request.Name,
            };

            _context.ProductCategory.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.ProductCategoryId;
        }
    }
}
