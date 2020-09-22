using AppShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShop.Domain.Entity
{
    public class CustomerEntity : CommonEntity
    {
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
