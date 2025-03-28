using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesApi.Data;
using SalesApi.Models;
using Microsoft.EntityFrameworkCore;
using SalesApi.DTOs;
namespace SalesApi.Services
{
    public class DepartmentService
    {
        private readonly DataContext _context;

        public DepartmentService(DataContext context){
            _context = context;
        }

        public async Task<List<DepartmentDTO>> GetDepartmentsAsync(){
            List<Department> departments = await _context.Department.ToListAsync();
            List<DepartmentDTO> departmentsDTO = new List<DepartmentDTO>();
            foreach(Department department in departments){
                
                departmentsDTO.Add(ConvertToDTO(department));
            }
            return departmentsDTO;
        }

         public async Task InsertAsync(DepartmentDTO obj){
            Department dep = ConvertToDepartment(obj);
            _context.Department.Add(dep);
            await _context.SaveChangesAsync();
        }
        public DepartmentDTO ConvertToDTO(Department department){
            return new DepartmentDTO(department.Id,department.Name);
        }

        public Department ConvertToDepartment(DepartmentDTO departmentdto){
            return new Department(departmentdto.Id,departmentdto.Name);
        }
    }
}