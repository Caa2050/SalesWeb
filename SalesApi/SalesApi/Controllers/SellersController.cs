using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Data;
using SalesApi.Services;
using SalesApi.Models;
using SalesApi.DTOs;
using SalesApi.Services.Exceptions;
namespace SalesApi.Controllers
{
    [ApiController]
    [Route("SalesApi/Seller")]
    public class SellersController : ControllerBase
    {
        private readonly SellerService _sellerservice;

        public SellersController(SellerService sellerservice){
            _sellerservice = sellerservice;
        }

        [HttpGet]
        public async Task<ActionResult<List<SellerDTO>>> GetAllSellers(){
            List<SellerDTO> sellers = new List<SellerDTO>();
            sellers = await _sellerservice.FindAllAsync();
            return sellers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SellerDTO>> GetById(int id){
            SellerDTO sel = await _sellerservice.FindByIdAsync(id);
            return sel;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
                await _sellerservice.RemoveAsync(id);
                return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SellerDTO seller){
            await _sellerservice.InsertAsync(seller);
            return Ok();
        }

        [HttpPut]
        public async  Task<IActionResult> Edit(SellerDTO obj){
            try{
                await _sellerservice.UpdateAsync(obj);
                return Ok();
            }
            catch(NotFoundException){
                return NotFound();
            }
            catch(DbConcurrencyException){
                return BadRequest();
            }
        }
    }
}