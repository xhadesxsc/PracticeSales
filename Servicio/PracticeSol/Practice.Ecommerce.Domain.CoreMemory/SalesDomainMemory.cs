using Practice.Ecommerce.Domain.Entity;
using Practice.Ecommerce.Domain.InterfaceMemory;
using Practice.Ecommerce.Infrastructure.InterfaceMemory;
using System;
using System.Collections.Generic;

namespace Practice.Ecommerce.Domain.CoreMemory
{
    public class SalesDomainMemory : ISalesDomainMemory
    {
        private readonly ISalesInMemory _salesRepositoryMemory;
        public SalesDomainMemory(ISalesInMemory saleRepository)
        {
            _salesRepositoryMemory = saleRepository;
        }

        #region Métodos Síncronos

        public bool InsertMemory(Sales sales)
        {
            return _salesRepositoryMemory.InsertMemory(sales);
        }

        public IEnumerable<Sales> GetAllMemory()
        {
            return _salesRepositoryMemory.GetAllMemory();
        }

        #endregion
    }
}
