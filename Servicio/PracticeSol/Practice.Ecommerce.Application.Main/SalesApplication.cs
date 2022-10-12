using AutoMapper;
using Practice.Ecommerce.Application.DTO;
using Practice.Ecommerce.Application.Interface;
using Practice.Ecommerce.Domain.Entity;
using Practice.Ecommerce.Domain.Interface;
using Practice.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Ecommerce.Application.Main
{
    public class SalesApplication: ISalesApplication
    {
        private readonly ISalesDomain _salesDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<SalesApplication> _logger;
        public SalesApplication(ISalesDomain salesDomain, IMapper mapper, IAppLogger<SalesApplication> logger)
        {
            _salesDomain = salesDomain;
            _mapper = mapper;
            _logger = logger;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(SalesDto salesDto)
        {
            var response = new Response<bool>();
            try
            {
                var sales = _mapper.Map<Sales>(salesDto);
                response.Data = _salesDomain.Insert(sales);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Update(SalesDto salesDto)
        {
            var response = new Response<bool>();
            try
            {
                var sales = _mapper.Map<Sales>(salesDto);
                response.Data = _salesDomain.Update(sales);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Delete(string salesId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _salesDomain.Delete(salesId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<SalesDto> Get(string salesId)
        {
            var response = new Response<SalesDto>();
            try
            {
                var sales = _salesDomain.Get(salesId);
                response.Data = _mapper.Map<SalesDto>(sales);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<IEnumerable<SalesDto>> GetAll()
        {
            var response = new Response<IEnumerable<SalesDto>>();
            try
            {
                var customers = _salesDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<SalesDto>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.LogInformation("Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        #endregion

        #region Métodos Asíncronos
        public async Task<Response<bool>> InsertAsync(SalesDto salesDto)
        {
            var response = new Response<bool>();
            try
            {
                var sales = _mapper.Map<Sales>(salesDto);
                response.Data = await _salesDomain.InsertAsync(sales);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<bool>> UpdateAsync(SalesDto salesDto)
        {
            var response = new Response<bool>();
            try
            {
                var sales = _mapper.Map<Sales>(salesDto);
                response.Data = await _salesDomain.UpdateAsync(sales);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string salesId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _salesDomain.DeleteAsync(salesId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<SalesDto>> GetAsync(string salesId)
        {
            var response = new Response<SalesDto>();
            try
            {
                var sales = await _salesDomain.GetAsync(salesId);
                response.Data = _mapper.Map<SalesDto>(sales);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<SalesDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<SalesDto>>();
            try
            {
                var customers = await _salesDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<SalesDto>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        #endregion
    }
}
