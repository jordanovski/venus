namespace Venus.Data
{
    using System.Data.Entity;
    using Venus.Model;

    public partial class VenusContext : DbContext
    {
        public VenusContext()
            : base("name=VenusContext")
        {
        }

        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Orders)
                .HasForeignKey(e => e.OrderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Products)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tables>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Tables)
                .HasForeignKey(e => e.TableId)
                .WillCascadeOnDelete(false);
        }
    }
}
