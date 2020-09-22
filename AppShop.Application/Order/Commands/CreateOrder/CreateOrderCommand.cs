using AppShop.Application.Common.Interfaces;
using AppShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using MediatR;

namespace AppShop.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<OrderVmlList>
    {
        public int OrderId { get; set; }
        public string OrderGroup { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderVmlList>
    {
        private readonly IAppDbContext _context;
     
        public CreateOrderCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<OrderVmlList> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            OrderVmlList orderVms = new OrderVmlList();
            var entity = new OrderEntity
            {
                OrderGroup = string.IsNullOrEmpty(request.OrderGroup) ? Guid.NewGuid().ToString() : request.OrderGroup,
                ProductId = request.ProductId,
                Quantity = request.Quantity
            };

            try
            {
                _context.Orders.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);


                orderVms.orderlist = await (from o in _context.Orders
                                            join p in _context.Products on o.ProductId equals p.ProductId
                                            where o.OrderGroup == entity.OrderGroup
                                            select new OrderVm()
                                            {
                                                ProductName = p.Name,
                                                Quantity = o.Quantity,
                                                OrderGroup = o.OrderGroup,
                                                Price = p.Price,
                                                Amount = p.Price * Convert.ToDecimal(o.Quantity)
                                            }).ToListAsync();


                

                foreach (OrderVm order in orderVms.orderlist)
                {
                    orderVms.GrandTotal += order.Amount;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return orderVms;
        }
    }
}
