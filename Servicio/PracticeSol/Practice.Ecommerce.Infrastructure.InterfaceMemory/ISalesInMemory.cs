using Practice.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Ecommerce.Infrastructure.InterfaceMemory
{
    public interface ISalesInMemory
    {
        bool InsertMemory(Sales sales);
        IEnumerable<Sales> GetAllMemory();
    }
}
