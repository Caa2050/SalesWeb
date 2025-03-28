using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesApi.Models.Enums;
namespace SalesApi.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status {get;set;}
 
        public int SellerId {get;set;}
        public Seller Seller { get; set; }

        public SalesRecord(){

        }
        public SalesRecord(int id,DateTime date, double amount, SaleStatus status, int sellerid){
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            SellerId = sellerid;
           
        }
    }
}
