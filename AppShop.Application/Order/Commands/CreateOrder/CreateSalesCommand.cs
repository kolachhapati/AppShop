using AppShop.Application.Common.Interfaces;
using AppShop.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppShop.Application.Order.Commands.CreateOrder
{
    public class CreateSalesCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string OrderGroup { get; set; }
        public decimal Total { get; set; }
        //public int? CustomerId { get; set; }
    }

    public class CreateSalesCommandHandler : IRequestHandler<CreateSalesCommand, string>
    {
        private readonly IAppDbContext _context;

        public CreateSalesCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(CreateSalesCommand request, CancellationToken cancellationToken)
        {
            var customer = new CustomerEntity()
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email
            };

            try
            {
                await _context.BeginTransactionAsync();
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync(cancellationToken);

                var sales = new SalesEntity()
                {
                    OrderGroup = request.OrderGroup,
                    CustomerId = customer.CustomerId,
                    Total = request.Total
                };
                _context.Sales.Add(sales);
                await _context.SaveChangesAsync(cancellationToken);

                await _context.CommitTransactionAsync();
            }
            catch (Exception)
            {
                _context.RollbackTransaction();
                throw;
            }
            return customer.CustomerId;
        }

    }
}