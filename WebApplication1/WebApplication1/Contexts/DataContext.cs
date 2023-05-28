using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.DataEntities;
using WebApplication1.Models.Entities;

namespace WebApplication1.Contexts;

public class DataContext : IdentityDbContext<UserEntity>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<AddressEntity> Addresses { set; get; }
    public DbSet<UserAddressEntity> UserAddresses { set; get; }
    public DbSet<ProductEntity> Products { set; get; }
    public DbSet<OrderEntity> Orders { set; get; }
    public DbSet<OrderDetailsEntity> OrderDetails { set; get; }
    public DbSet<InvoiceEntity> Invoices { set; get; }
    public DbSet<ShoppingCartEntity> ShoppingCarts { set; get; }
    public DbSet<WishListEntity> WishLists { set; get; }
    public DbSet<OrderStatus> OrderStatus { set; get; }
    public DbSet<CategoryEntity> Categories { set; get; }
    public DbSet<PaymentMethod> PaymentMethods { set; get; }
    public DbSet<PaymentStatus> PaymentStatus { set; get; }
    public DbSet<ContactEntity> Contacts { set; get; }
    public DbSet<TagEntity> Tags { set; get; }
    public DbSet<ProductTagEntity> ProductTags { set; get; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "a31a09f7-df8e-4cdd-a2ec-fd5d88fdd080",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            },
            new IdentityRole
            {
                Id = "6d46aad8-cbf0-4726-bd4d-b2cac09ae270",
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            });
        /*
        var passwordHasher = new PasswordHasher<UserEntity>();
        var userAdmin = new UserEntity
        {
            Id = "eb9e450c-19ae-41aa-955b-faac3aff8191",
            UserName = "admin@domain.com",
            NormalizedUserName = "ADMIN@DOMAIN.COM ",
            Email = "admin@domain.com",
            NormalizedEmail = "ADMIN@DOMAIN.COM ",
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };
        userAdmin.PasswordHash = passwordHasher.HashPassword(userAdmin, "ReplaceMe123");
        builder.Entity<UserEntity>().HasData(userAdmin);

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            UserId = userAdmin.Id,
            RoleId = "a31a09f7-df8e-4cdd-a2ec-fd5d88fdd080"
        });

        */

        builder.Entity<TagEntity>().HasData(
            new TagEntity { Id = 1, Title = "New" },
            new TagEntity { Id = 2, Title = "Featured" },
            new TagEntity { Id = 3, Title = "Popular" }
        );

        builder.Entity<OrderStatus>().HasData(
            new OrderStatus { Id = 1, Status = "Pending" },
            new OrderStatus { Id = 2, Status = "Cancelled" },
            new OrderStatus { Id = 3, Status = "Recieved" },
            new OrderStatus { Id = 4, Status = "Under Proccessing" },
            new OrderStatus { Id = 5, Status = "Under Shipping" },
            new OrderStatus { Id = 6, Status = "Delivered" },
            new OrderStatus { Id = 7, Status = "Returned" }
        );

        builder.Entity<PaymentStatus>().HasData(
            new PaymentStatus { Id = 1, Status = "Pending" },
            new PaymentStatus { Id = 2, Status = "Paid" },
            new PaymentStatus { Id = 3, Status = "Unpaid" },
            new PaymentStatus { Id = 4, Status = "Delayed" },
            new PaymentStatus { Id = 5, Status = "Denied" }
        );

        builder.Entity<PaymentMethod>().HasData(
            new PaymentMethod { Id = 1, Method = "PayPal" },
            new PaymentMethod { Id = 2, Method = "Visa Card" },
            new PaymentMethod { Id = 3, Method = "Master Card" },
            new PaymentMethod { Id = 4, Method = "Invoice" }
        );

        builder.Entity<CategoryEntity>().HasData(
            new CategoryEntity { Id = 1, Title = "Shoes" },
            new CategoryEntity { Id = 2, Title = "Bags" },
            new CategoryEntity { Id = 3, Title = "Dress" },
            new CategoryEntity { Id = 4, Title = "Decorations" },
            new CategoryEntity { Id = 5, Title = "Essintials" },
            new CategoryEntity { Id = 6, Title = "Interior" },
            new CategoryEntity { Id = 7, Title = "Laptop" },
            new CategoryEntity { Id = 8, Title = "Mobile" },
            new CategoryEntity { Id = 9, Title = "Beauty" },
            new CategoryEntity { Id = 10, Title = "Electronic" }
        );
    }
}
