using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.DTOs
{
    public class SellerDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; }   
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public int DepartmentId{get;set;}

        public SellerDTO(){}

        public SellerDTO(int id, string name, string email, DateTime birthdate, double baseSalary, int departmentId){
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthdate;
            BaseSalary = baseSalary;
            DepartmentId = departmentId; 
        }
    }
}