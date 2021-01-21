using AppShop.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppShop.Application.Product.Commands.DeleteProduct
{
    public class DeleteProductCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteProductCategoryCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductCategory.FindAsync(request.Id);

            if (entity != null)
            {
                _context.ProductCategory.Remove(entity);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
