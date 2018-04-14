using System;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Persistence
{
    public class FactVentoryDbContext : DbContext
    {
        public DbSet<Costumer> Costumer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }


        public FactVentoryDbContext(DbContextOptions<FactVentoryDbContext> options)
            :base(options)
        { }
    }
}
