using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppShop.Application.Common.Interfaces;
using System.Linq;
using MediatR;

namespace AppShop.Application.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<string>
    {
        public int Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, string>
    {
        private readonly IAppDbContext _context;

        public DeleteProductCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.Products.Where(x => x.ProductId == request.Id).SingleOrDefault();
            string output= "";
            if (entity != null)
            {
                try
                {
                    _context.Products.Remove(entity);
                    await _context.SaveChangesAsync(cancellationToken);
                    output = "Success";
                }
                catch (Exception)
                {
                    output = "Failure";
                }
            }

            return output;
        }
    }
}
