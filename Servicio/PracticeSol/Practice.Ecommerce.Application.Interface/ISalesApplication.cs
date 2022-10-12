using Practice.Ecommerce.Application.DTO;
using Practice.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Ecommerce.Application.Interface
{
    public interface ISalesApplication
    {
        #region Métodos Síncronos
        Response<bool> Insert(SalesDto salesDto);
        Response<bool> Update(SalesDto salesDto);
        Response<bool> Delete(string salesId);

        Response<SalesDto> Get(string salesId);
        Response<IEnumerable<SalesDto>> GetAll();

        #endregion

        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(SalesDto salesDto);
        Task<Response<bool>> UpdateAsync(SalesDto salesDto);
        Task<Response<bool>> DeleteAsync(string salesId);

        Task<Response<SalesDto>> GetAsync(string salesId);
        Task<Response<IEnumerable<SalesDto>>> GetAllAsync();
        #endregion
    }
}
