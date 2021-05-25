namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SuperWareDbContext : DbContext
    {
        public SuperWareDbContext()
            : base("name=SuperWareDbContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Deverily> Deverilies { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Pattern> Patterns { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Prority> Prorities { get; set; }
        public virtual DbSet<ReqStock> ReqStocks { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deverily>()
                .Property(e => e.OderID)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderID)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.ProductID)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Deverilies)
                .WithOptional(e => e.Order)
                .HasForeignKey(e => e.OderID);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductID)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Barcode)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.NameEnglish)
                .IsUnicode(false);

            modelBuilder.Entity<Promotion>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Promotion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prority>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Prority)
                .HasForeignKey(e => e.PriorityID);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UserRole").MapLeftKey("RoleID").MapRightKey("UserID"));

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.SaleID);
        }
    }
}
