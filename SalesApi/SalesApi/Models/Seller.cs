using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
        public int DepartmentId{get;set;}
        public Department Department {get;set;}

        public ICollection<SalesRecord> SalesRecord { get; set; } = new List<SalesRecord>();

        public Seller(){

        }

        public Seller(int id,string name,string email,DateTime birthDate,double basesalary, int departmentid){
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = basesalary;
            DepartmentId = departmentid;

        }

        public void AddSales(SalesRecord sr){
            SalesRecord.Add(sr);
        }

        public void RemoveSales(SalesRecord sr){
            SalesRecord.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final){
            return SalesRecord.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}