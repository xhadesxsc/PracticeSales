using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practice.Ecommerce.Application.DTO;
using Practice.Ecommerce.Application.Interface;
using Practice.Ecommerce.Domain.Entity;
using Practice.Ecommerce.Transversal.Common;
using Practice.Ecommerce.Transversal.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Ecommerce.Services.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SalesController : Controller
    {
        private readonly ISalesApplication _salesApplication;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SalesController(ISalesApplication salesApplication, IMapper mapper, ApplicationDbContext context)
        {
            _salesApplication = salesApplication;
            _mapper = mapper;
            _context = context;
        }

        #region "Métodos Sincronos"

        [HttpPost("Insert")]
        public async Task<ActionResult<int>> Post([FromForm] SalesDto salesDto)
        {
            if (salesDto == null)
                return BadRequest();
            var response = _salesApplication.Insert(salesDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] SalesDto salesDto)
        {
            if (salesDto == null)
                return BadRequest();
            var response = _salesApplication.Update(salesDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{salesId}")]
        public IActionResult Delete(string salesId)
        {
            if (string.IsNullOrEmpty(salesId))
                return BadRequest();
            var response = _salesApplication.Delete(salesId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{salesId}")]
        public IActionResult Get(string salesId)
        {
            if (string.IsNullOrEmpty(salesId))
                return BadRequest();
            var response = _salesApplication.Get(salesId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var response = _salesApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }
        #endregion

        #region "Métodos Asincronos"

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] SalesDto salesDto)
        {
            if (salesDto == null)
                return BadRequest();
            var response = await _salesApplication.InsertAsync(salesDto);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] SalesDto salesDto)
        {
            if (salesDto == null)
                return BadRequest();
            var response = await _salesApplication.UpdateAsync(salesDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteAsync/{salesId}")]
        public async Task<IActionResult> DeleteAsync(string salesId)
        {
            if (string.IsNullOrEmpty(salesId))
                return BadRequest();
            var response = await _salesApplication.DeleteAsync(salesId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAsync/{salesId}")]
        public async Task<IActionResult> GetAsync(string salesId)
        {
            if (string.IsNullOrEmpty(salesId))
                return BadRequest();
            var response = await _salesApplication.GetAsync(salesId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _salesApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        #endregion

        [HttpGet("todos")]
        public async Task<ActionResult<List<SalesDto>>> Todos()
        {
            var response = await _salesApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }


        [HttpGet("GetAllMemory")]
        public async Task<ActionResult<SalesDto>> GetAllMemory()
        {
            var response = new Response<List<SalesDto>>();
            var sales =  _context.Sales.ToList();
            if (sales != null)
            {
                response.Data = sales.Count>0?_mapper.Map<List<SalesDto>>(sales): new List<SalesDto>();
                response.IsSuccess = true;
                response.Message = "Listado Correcto";
                return Ok(response);
            }
            else
            {
                response.Message = "Error listado";
            }
            return BadRequest(response.Message);
        }

        [HttpPost("InsertMemory")]
        public async Task<ActionResult<int>> InsertMemory([FromForm] SalesDto salesDto)
        {
            if (salesDto == null)
                return BadRequest();
           _context.Add(_mapper.Map<Sales>(salesDto));
            if (_context.SaveChanges()>0)
                return Ok();

            return BadRequest();
        }
    }
}
