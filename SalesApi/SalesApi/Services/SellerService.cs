using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesApi.Data;
using SalesApi.Models;
using SalesApi.DTOs;
using SalesApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
namespace SalesApi.Services
{
    public class SellerService
    {
        private readonly DataContext _context;

        public SellerService (DataContext context){
            _context = context;
        }

        public async Task<List<SellerDTO>> FindAllAsync(){
            List<Seller> sellers = await _context.Seller.ToListAsync();
            List<SellerDTO> sellersDTO = new List<SellerDTO>();
            foreach(Seller seller in sellers){
                sellersDTO.Add(convertToDTO(seller));
            }
            return sellersDTO;
        }

        public async Task<SellerDTO> FindByIdAsync(int Id){
            Seller sel = await  _context.Seller.FirstOrDefaultAsync(obj => obj.Id == Id);
            SellerDTO selDTO = convertToDTO(sel);
            return selDTO;
        }

        public async Task RemoveAsync(int Id){
            try{
                var obj = await _context.Seller.FindAsync(Id);
                 _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }catch(DbUpdateException e){
                throw new IntegrityException("Can't delete seller because he/she has sales");
            }
            
        }

        public async Task InsertAsync(SellerDTO obj){
            Seller seller = convert(obj);
            _context.Seller.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SellerDTO obj){
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny){
                throw new NotFoundException("Id not found");
            }
            try{
                Seller sel = convert(obj);
                 _context.Update(sel);
                await _context.SaveChangesAsync();
            }
            catch( DbUpdateConcurrencyException e){
                throw new DbConcurrencyException(e.Message);
            }
           
        }
        public Seller convert(SellerDTO obj){
            Seller sellerdto = new Seller(obj.Id,obj.Name,obj.Email,obj.BirthDate,obj.BaseSalary,obj.DepartmentId);
            return sellerdto;
        }

        public SellerDTO convertToDTO(Seller obj){
            SellerDTO sellerdto = new SellerDTO(obj.Id,obj.Name,obj.Email,obj.BirthDate,obj.BaseSalary,obj.DepartmentId);
            return sellerdto;
        }

    }
}