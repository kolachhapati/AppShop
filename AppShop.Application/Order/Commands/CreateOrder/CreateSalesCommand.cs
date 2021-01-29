using AppShop.Application.Common.Interfaces;
using AppShop.Application.Order.Commands.CreateOrder.ViewModel;
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
        public DateTime PickUpDate { get; set; }
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
            string invoiceNumber = string.Empty;
            var result = new object();
            bool existingCustomer = true;
            var invoiceId = 1;
            try
            {
                CustomerEntity customer = _context.Customers.Where(c => c.PhoneNumber == request.PhoneNumber).SingleOrDefault();
                var lastSales = _context.Sales.OrderByDescending(x => x.SalesId).FirstOrDefault();
                if (lastSales != null)
                {
                    invoiceId = lastSales.SalesId + 1;
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
                invoiceNumber = "ORD-" + customer.PhoneNumber + "-" + invoiceId.ToString();

                await _context.BeginTransactionAsync();
                if (!existingCustomer)
                {
                    _context.Customers.Add(customer);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    if (!string.IsNullOrEmpty(request.Name))
                        customer.Name = request.Name;
                    if (!string.IsNullOrEmpty(request.Email))
                        customer.Email = request.Email;
                    _context.Customers.Update(customer);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                var sales = new SalesEntity()
                {
                    OrderGroup = request.OrderGroup,
                    CustomerId = customer.CustomerId,
                    InvoiceNumber = invoiceNumber,
                    Total = request.Total,
                    PickUpDate = request.PickUpDate
                };
                _context.Sales.Add(sales);
                await _context.SaveChangesAsync(cancellationToken);

                await _context.CommitTransactionAsync();

                IEnumerable<OrderEntity> orderEntities =  _context.Orders.Where(x => x.OrderGroup == request.OrderGroup).ToList();
                var totalOrders = orderEntities.Count();

                result = new DocketVm()
                {
                    CustomerName = customer.Name,
                    PhoneNumber = customer.PhoneNumber,
                    DocketNumber = invoiceNumber,
                    PickUpDetails = request.PickUpDate.ToString("dddd, dd MMMM yyyy") ,
                    Qty = totalOrders
                };
            }

            catch (Exception ex)
            {
                var exception = ex.Message.ToString();
                _context.RollbackTransaction();
                throw;
            }
            return JsonConvert.SerializeObject(result);
        }
    }
}