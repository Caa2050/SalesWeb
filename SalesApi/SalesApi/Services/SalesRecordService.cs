using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesApi.Data;
using SalesApi.Models;
using SalesApi.DTOs;
namespace SalesApi.Services
{
    public class SalesRecordService
    {
        private readonly DataContext _context;
        public SalesRecordService(DataContext context){
            _context = context;
        }

         public async Task InsertAsync(SalesRecordDTO obj){
            SalesRecord sales = ConvertToSeller(obj);
            _context.SalesRecord.Add(sales);
            await _context.SaveChangesAsync();
        } 
        public async Task<List<SalesRecordDTO>> GetSalesAsync(){
            List<SalesRecord> sales = await _context.SalesRecord.ToListAsync();
            List<SalesRecordDTO> salesDTO = new List<SalesRecordDTO>();
            foreach(SalesRecord s in sales){
                salesDTO.Add(ConvertToDTO(s));
            }
            return salesDTO;
        }
        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate){
            var result = from obj in _context.SalesRecord select obj;
            if(minDate.HasValue){
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if(maxDate.HasValue){
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result.Include(x => x.Seller).Include(x => x.Seller.Department).OrderByDescending(x => x.Date).ToListAsync();
        }

         public async Task<List<IGrouping<Department,SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate){
            var result = from obj in _context.SalesRecord select obj;
            if(minDate.HasValue){
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if(maxDate.HasValue){
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result.Include(x=> x.Seller).Include(x => x.Seller.Department).OrderByDescending(x => x.Date).GroupBy(x => x.Seller.Department).ToListAsync();
        }

        public SalesRecord ConvertToSeller(SalesRecordDTO obj){
            return new SalesRecord(obj.Id,obj.Date,obj.Amount,obj.Status,obj.SellerId);
        }
        public SalesRecordDTO ConvertToDTO(SalesRecord obj){
            return new SalesRecordDTO(obj.Id,obj.Date,obj.Amount,obj.Status,obj.SellerId);
        }
    }
}