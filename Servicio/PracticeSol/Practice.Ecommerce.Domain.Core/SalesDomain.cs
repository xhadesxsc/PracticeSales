using Practice.Ecommerce.Domain.Entity;
using Practice.Ecommerce.Domain.Interface;
using Practice.Ecommerce.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Ecommerce.Domain.Core
{
    public class SalesDomain: ISalesDomain
    {
        private readonly ISalesRepository _salesRepository;
        public SalesDomain(ISalesRepository saleRepository)
        {
            _salesRepository = saleRepository;
        }

        #region Métodos Síncronos

        public bool Insert(Sales sales)
        {
            return _salesRepository.Insert(sales);
        }

        public bool Update(Sales sales)
        {
            return _salesRepository.Update(sales);
        }

        public bool Delete(string salesId)
        {
            return _salesRepository.Delete(salesId);
        }

        public Sales Get(string salesId)
        {
            return _salesRepository.Get(salesId);
        }

        public IEnumerable<Sales> GetAll()
        {
            return _salesRepository.GetAll();
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Sales sales)
        {
            return await _salesRepository.InsertAsync(sales);
        }

        public async Task<bool> UpdateAsync(Sales sales)
        {
            return await _salesRepository.UpdateAsync(sales);
        }

        public async Task<bool> DeleteAsync(string salesId)
        {
            return await _salesRepository.DeleteAsync(salesId);
        }

        public async Task<Sales> GetAsync(string salesId)
        {
            return await _salesRepository.GetAsync(salesId);
        }

        public async Task<IEnumerable<Sales>> GetAllAsync()
        {
            return await _salesRepository.GetAllAsync();
        }

        #endregion
    }
}
