using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Data;
using SalesApi.Services;
using SalesApi.DTOs;
namespace SalesApi.Controllers
{
    [ApiController]
    [Route("SalesApi/SalesRecord")]
    public class SalesRecordController : ControllerBase
    {
        private readonly SalesRecordService _salesrecordservice;

        public  SalesRecordController(SalesRecordService salesrecordservice){
            _salesrecordservice = salesrecordservice;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SalesRecordDTO sales){
            await _salesrecordservice.InsertAsync(sales);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<SalesRecordDTO>>> GetAllDepartments(){
            List<SalesRecordDTO> sales = new List<SalesRecordDTO>();
            sales = await _salesrecordservice.GetSalesAsync();
            return sales;
        }
 
    }
}