using Practice.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Ecommerce.Domain.Interface
{
    public interface ISalesDomain
    {
        #region Métodos síncronos
        bool Insert(Sales sales);
        bool Update(Sales sales);
        bool Delete(string salesId);

        Sales Get(string salesId);
        IEnumerable<Sales> GetAll();

        #endregion

        #region Métodos Asíncronos
        Task<bool> InsertAsync(Sales sales);
        Task<bool> UpdateAsync(Sales sales);
        Task<bool> DeleteAsync(string salesId);

        Task<Sales> GetAsync(string salesId);
        Task<IEnumerable<Sales>> GetAllAsync();
        #endregion
    }
}
