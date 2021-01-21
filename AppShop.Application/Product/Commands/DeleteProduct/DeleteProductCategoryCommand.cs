using AppShop.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace AppShop.Application.Product.Commands.DeleteProduct
{
    public class DeleteProductCategoryCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, string>
    {
        private readonly IAppDbContext _context;

        public DeleteProductCategoryCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductCategory.FindAsync(request.Id);
            string output = "";
            if (entity != null)
            {
                try
                {
                    _context.ProductCategory.Remove(entity);
                    await _context.SaveChangesAsync(cancellationToken);
                    output = "Success";
                }
                catch (Exception ex)
                {
                    var err = ex.Message.ToString();
                    output = "Failure";
                }
            }

            return output;
        }
    }
}
