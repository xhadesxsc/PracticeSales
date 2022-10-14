using Practice.Ecommerce.Application.DTO;
using Practice.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;

namespace Practice.Ecommerce.Application.InterfaceMemory
{
    public interface ISalesApplicationMemory
    {
        #region Métodos Síncronos
        Response<bool> InsertMemory(SalesDto salesDto);
        Response<IEnumerable<SalesDto>> GetAllMemory();
        #endregion
    }
}
