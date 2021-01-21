using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppShop.Application.Common.Interfaces;
using MediatR;

namespace AppShop.Application.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand :IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteProductCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.Id);
             
            if (entity != null)
            {
               _context.Products.Remove(entity);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
