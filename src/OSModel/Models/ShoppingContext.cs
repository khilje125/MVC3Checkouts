using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;


namespace OSModel.Models
{
   public class ShoppingContext: DbContext
    {
       public ShoppingContext(): base("OnlineShoppingDB")
       {
           this.Configuration.ValidateOnSaveEnabled = false;
       }

       public DbSet<Categories> Categories { get; set; }
       public DbSet<Company> Compnay { get; set; }
       //public DbSet<cus> CustomePrices { get; set; }
       public DbSet<Customers> Customers { get; set; }
       public DbSet<Invoices> Invoices { get; set; }
       public DbSet<Offers> Offers { get; set; }
       public DbSet<OfferType> OfferType { get; set; }
       public DbSet<OrderDetail> OrderDetail { get; set; }
       public DbSet<Orders> Orders { get; set; }
       public DbSet<Payments> Payments { get; set; }
       public DbSet<Products> Products { get; set; }
       public DbSet<ProductsGroup> ProductsGroup { get; set; }
       public DbSet<RecordCreation> RecordCreation { get; set; }
       public DbSet<RecordModification> RecordModification { get; set; }
       public DbSet<Stock> Stock { get; set; }
       public DbSet<StockLog> StockLog { get; set; }
       public DbSet<User> Users { get; set; }
       public DbSet<UserType> Usertype { get; set; }
       //public DbSet<UserStatus> UserStatus { get; set; }
       public DbSet<CustomerPrices> CustomerPrices { get; set; }
       public DbSet<Suppliers> Suppliers { get; set; }
       public DbSet<ProductImages> ProductImages { get; set; }
       public DbSet<CustomerBillingAddress> CustomerBillingAddress { get; set; }


       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
           base.OnModelCreating(modelBuilder);
           modelBuilder.Entity<Categories>()
              .HasMany(x => x.SubCategories)
               .WithOptional()
               .HasForeignKey(g => g.ParentId);
       }
    }
}
