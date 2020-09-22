using System;
using System.Collections.Generic;
using System.Text;

namespace AppShop.Domain.Common
{
    public abstract class CommonEntity
    {
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
