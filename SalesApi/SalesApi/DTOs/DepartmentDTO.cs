using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name {get;set;}

        public DepartmentDTO(){}

        public DepartmentDTO(int id, string name){
            Id = id;
            Name = name;
        }
    }
}