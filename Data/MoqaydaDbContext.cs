using Microsoft.EntityFrameworkCore;
using MoqaydaGP.Entities;

namespace MoqaydaGP.Data
{
    public class MoqaydaDbContext:DbContext
    {
        public MoqaydaDbContext(DbContextOptions<MoqaydaDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<WishlistItem> WishlistItem { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ProductOwner> ProductOwner { get; set; }
        public DbSet<ProdToSwap> ProdToSwap { get; set; }
        public DbSet<PrivateItem> PrivateItem { get; set; }
       
        public DbSet<PrivateSwap> PrivateSwap { get; set; }
        public DbSet<BarteredProduct> BarteredProduct { get; set; }
        public DbSet<BarteredPrivateItem> BarteredPrivateItem { get; set; }
        public DbSet<PrivateItemOwner> PrivateItemOwner { get; set; }
        public DbSet<PrivToSwap> PrivToSwap { get; set; }
        public DbSet<BarteredPriv> BarteredPriv { get; set; }
        public DbSet<Block> Block { get; set; }
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<Category>()
                .HasMany(b => b.Product)
                .WithOne(b => b.Category)
                .OnDelete(DeleteBehavior.Cascade);
            Builder.Entity<User>()
               .HasMany(b => b.Product)
               .WithOne(b => b.User)
               .OnDelete(DeleteBehavior.Cascade);
            Builder.Entity<Product>()
                .HasMany(b => b.WishlistItem)
                .WithOne(b => b.Product)
               .OnDelete(DeleteBehavior.Cascade);
            Builder.Entity<User>()
              .HasMany(b => b.PrivateItem)
              .WithOne(b => b.User)
              .OnDelete(DeleteBehavior.Cascade);
           
            Builder.Entity<User>()
              .HasMany(b => b.ProductOwner)
              .WithOne(b => b.User)
              .OnDelete(DeleteBehavior.Cascade);
            Builder.Entity<ProductOwner>()
              .HasMany(b => b.ProdToSwap)
              .WithOne(b => b.ProductOwner)
              .OnDelete(DeleteBehavior.Cascade);
            Builder.Entity<ProductOwner>()
               .HasMany(b => b.PrivateSwap)
               .WithOne(b => b.ProductOwner)
               .OnDelete(DeleteBehavior.Cascade);
            Builder.Entity<ProductOwner>()
             .HasMany(b => b.BarteredProduct)
             .WithOne(b => b.ProductOwner)
             .OnDelete(DeleteBehavior.Cascade);
            Builder.Entity<ProductOwner>()
             .HasMany(b => b.BarteredPrivateItem)
             .WithOne(b => b.ProductOwner)
             .OnDelete(DeleteBehavior.Cascade);
            Builder.Entity<User>()
             .HasMany(b => b.PrivateItemOwner)
             .WithOne(b => b.User)
             .OnDelete(DeleteBehavior.Cascade);
            Builder.Entity<PrivateItemOwner>()
              .HasMany(b => b.PrivToSwap)
              .WithOne(b => b.PrivateItemOwner)
              .OnDelete(DeleteBehavior.Cascade);
            Builder.Entity<PrivateItemOwner>()
             .HasMany(b => b.BarteredPriv)
             .WithOne(b => b.PrivateItemOwner)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
