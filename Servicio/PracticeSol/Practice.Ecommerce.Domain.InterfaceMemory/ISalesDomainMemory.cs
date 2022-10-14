using Practice.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Practice.Ecommerce.Domain.InterfaceMemory
{
    public interface ISalesDomainMemory
    {
        bool InsertMemory(Sales sales);
        IEnumerable<Sales> GetAllMemory();
    }
}
