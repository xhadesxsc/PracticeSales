using AutoMapper;
using Practice.Ecommerce.Application.DTO;
using Practice.Ecommerce.Application.InterfaceMemory;
using Practice.Ecommerce.Domain.Entity;
using Practice.Ecommerce.Domain.InterfaceMemory;
using Practice.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;

namespace Practice.Ecommerce.Application.MainMemory
{
    public class SalesApplicationMemory : ISalesApplicationMemory
    {
        private readonly ISalesDomainMemory _salesDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<SalesApplicationMemory> _logger;
        public SalesApplicationMemory(ISalesDomainMemory salesDomain, IMapper mapper, IAppLogger<SalesApplicationMemory> logger)
        {
            _salesDomain = salesDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public Response<IEnumerable<SalesDto>> GetAllMemory()
        {
            var response = new Response<IEnumerable<SalesDto>>();
            try
            {
                var customers = _salesDomain.GetAllMemory();
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

        public Response<bool> InsertMemory(SalesDto salesDto)
        {
            var response = new Response<bool>();
            try
            {
                var sales = _mapper.Map<Sales>(salesDto);
                response.Data = _salesDomain.InsertMemory(sales);
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
    }
}
