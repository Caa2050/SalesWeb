using Microsoft.EntityFrameworkCore;
using SalesApi.Models;
using SalesApi.Models.Enums;
namespace SalesApi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){

        }

        public DbSet<Department> Department {get;set;}
        public DbSet<SalesRecord> SalesRecord {get;set;}
        public DbSet<Seller> Seller{get;set;}
        
        protected override void OnModelCreating (ModelBuilder modelbuilder){
            modelbuilder.Entity<Department>().HasMany(dep => dep.Sellers).WithOne(dep => dep.Department).HasForeignKey(dep => dep.DepartmentId).HasPrincipalKey(dep => dep.Id);
            modelbuilder.Entity<Seller>().HasMany(seller => seller.SalesRecord).WithOne(seller => seller.Seller).HasForeignKey(seller => seller.SellerId).HasPrincipalKey(seller => seller.Id);
            modelbuilder.Entity<SalesRecord>().HasKey(salesrecord => salesrecord.Id);
            
            modelbuilder.Entity<Department>().HasData(new Department {Id = 1,Name = "Computers"});
            modelbuilder.Entity<Department>().HasData(new Department {Id = 2, Name = "Electronics"});
            modelbuilder.Entity<Department>().HasData(new Department {Id = 3, Name = "Fashion"});
            modelbuilder.Entity<Department>().HasData(new Department {Id = 4,Name = "Books"});

            modelbuilder.Entity<Seller>().HasData(new Seller{Id = 1, Name = "Bob", Email = "bob@gmail.com", BirthDate = new DateTime(1998,4,21), BaseSalary = 3200.0, DepartmentId = 1 });
            modelbuilder.Entity<Seller>().HasData(new Seller{Id = 2, Name = "Carl", Email = "carl@gmail.com", BirthDate = new DateTime(1993,4,21), BaseSalary = 2000.0, DepartmentId = 2 });
            modelbuilder.Entity<Seller>().HasData(new Seller{Id = 3, Name = "Nick", Email = "nick@gmail.com", BirthDate = new DateTime(1990,4,21), BaseSalary = 4000.0, DepartmentId = 3 });
            modelbuilder.Entity<Seller>().HasData(new Seller{Id = 4, Name = "Kate", Email = "kate@gmail.com", BirthDate = new DateTime(2000,4,21), BaseSalary = 2500.0, DepartmentId = 4 });

            modelbuilder.Entity<SalesRecord>().HasData(new SalesRecord{Id= 1, Date = new DateTime(2018,9,24), Amount = 200.0, Status = SaleStatus.Billed, SellerId = 1});
            modelbuilder.Entity<SalesRecord>().HasData(new SalesRecord{Id  = 2, Date = new DateTime(2018,9,4), Amount = 300.0, Status = SaleStatus.Pending,SellerId = 2});
            modelbuilder.Entity<SalesRecord>().HasData(new SalesRecord{Id = 3, Date = new DateTime(2018,9,15), Amount = 400.0, Status = SaleStatus.Cancelled,SellerId = 3});
            modelbuilder.Entity<SalesRecord>().HasData(new SalesRecord{Id = 4, Date = new DateTime(2019,8,20), Amount = 500.0, Status = SaleStatus.Billed, SellerId = 4});

            

        }
    }
}