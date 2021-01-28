using AppShop.Application.Common.Interfaces;
using AppShop.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppShop.Application.Order.Queries.GetOrder
{
    public class GetOrderQuery : IRequest<List<GetSalesVm>>
    {
    }

    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, List<GetSalesVm>>
    {
        private readonly IAppDbContext _context;

        public GetOrderQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<List<GetSalesVm>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            List<GetSalesVm> salesList = await (from s in _context.Sales
                                                join c in _context.Customers on s.CustomerId equals c.CustomerId
                                                select new GetSalesVm()
                                                {
                                                   SalesId = s.SalesId,
                                                   PhoneNumber = c.PhoneNumber,
                                                   Email = c.Email,
                                                   OrderGroup = s.OrderGroup,
                                                   Total = s.Total,
                                                   Name = c.Name
                                                }).OrderByDescending(s => s.SalesId).ToListAsync();

            return salesList;
        }
    }
}
