using Microsoft.EntityFrameworkCore;

namespace DevsonMotors.Models
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions options): base(options) { }
        DbSet<Order> Order { get;set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<Supplier> Supplier { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<OrderDetails> OrderDetails { get; set; }

    }
}

