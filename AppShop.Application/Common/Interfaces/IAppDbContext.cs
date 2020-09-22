using AppShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppShop.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<ProductEntity> Products { get; set; }
        DbSet<OrderEntity> Orders { get; set; }
        DbSet<CustomerEntity> Customers { get; set; }
        DbSet<SalesEntity> Sales { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task BeginTransactionAsync();
        void RollbackTransaction();
        Task CommitTransactionAsync();
    }
}
