using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: Db tabloları ile proje class'larını bağlamak
    public class NorthwindContext : DbContext//DbContext: Entity Framework ile gelen base class'tır. Bizim context'imizdir.
    {
        //Hangi veritabanı;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//Bu metot ile projenin hangi veritabanıyla ilişkili olduğunu belirtiriz.
        {
            //Trusted_Connection=true: Kullanıcı adı şifre gerektirmeden bağlanmak için, doğrusu budur. Kullanıcı adı ve şifrenin olması riskli
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");//Sql Server kullanacağımı belirtiyorum. @"Server=175.45.2.12 gerçek projede buna benzer bir ip olur
        }


        //Hangi nesnenin hangi nesneye (hangi class'ın hangi tabloya) karşılık geldiğini DbSet ile belirtiriz;
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
