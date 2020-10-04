using AppShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShop.Domain.Entity
{
    public class ProductCategoryEntity : CommonEntity
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
    }
}
