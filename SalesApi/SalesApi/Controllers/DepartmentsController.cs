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
    [Route("SalesApi/Department")]
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentService _service;

        public DepartmentsController(DepartmentService service){
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentDTO department){
            await _service.InsertAsync(department);
            return Ok();
        }
        
        [HttpGet]
        public async Task<ActionResult<List<DepartmentDTO>>> GetAllDepartments(){
            List<DepartmentDTO> department = new List<DepartmentDTO>();
            department = await _service.GetDepartmentsAsync();
            return department;
        }
    }
}