using Practice.Ecommerce.Domain.Entity;
using Practice.Ecommerce.Infrastructure.InterfaceMemory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Ecommerce.Infrastructure.Memory
{
    public class SalesInMemory: ISalesInMemory
    {
        private readonly ApplicationDbContext _context;

        public SalesInMemory(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool InsertMemory(Sales sales)
        {
            _context.Add(sales);
            return _context.SaveChanges()>0;
        }

        public IEnumerable<Sales> GetAllMemory()
        {
                var customers = _context.Sales.AsQueryable();
                return customers;
        }
    }
}
