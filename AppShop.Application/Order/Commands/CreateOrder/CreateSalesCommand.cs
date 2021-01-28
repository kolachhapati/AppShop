using AppShop.Application.Common.Interfaces;
using AppShop.Domain.Entity;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
            CustomerEntity customer = _context.Customers.Where(c => c.PhoneNumber == request.PhoneNumber).SingleOrDefault();
            string invoiceNumber = string.Empty;
            bool existingCustomer = true;
            var invoiceId = 1;
            var maxSalesId = _context.Sales.OrderByDescending(x => x.SalesId).FirstOrDefault();
            if (maxSalesId != null)
            {
                invoiceId = maxSalesId.SalesId + 1;
            }


            if (customer == null)
            {
                customer = new CustomerEntity()
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email
                };
                existingCustomer = false;
            }
            try
            {
                invoiceNumber = "ORD-" + customer.PhoneNumber + "-" + invoiceId.ToString();

                await _context.BeginTransactionAsync();
                if (!existingCustomer)
                {
                    if (!string.IsNullOrEmpty(request.Name))
                        customer.Name = request.Name;
                    if (!string.IsNullOrEmpty(request.Email))
                        customer.Email = request.Email;

                    _context.Customers.Add(customer);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    _context.Customers.Update(customer);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                var sales = new SalesEntity()
                {
                    OrderGroup = request.OrderGroup,
                    CustomerId = customer.CustomerId,
                    InvoiceNumber = invoiceNumber,
                    Total = request.Total
                };
                _context.Sales.Add(sales);
                await _context.SaveChangesAsync(cancellationToken);

                await _context.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                var exception = ex.Message.ToString();
                _context.RollbackTransaction();
                throw;
            }

            return  JsonConvert.SerializeObject(invoiceNumber);
        }

    }
}