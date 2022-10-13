using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practice.Ecommerce.Application.DTO;
using Practice.Ecommerce.Application.Interface;
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
        public SalesController(ISalesApplication salesApplication)
        {
            _salesApplication = salesApplication;
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
    }
}
