using HomeAccounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.Data;

public class HomeAccountingDbContext : DbContext
{
    public HomeAccountingDbContext(DbContextOptions<HomeAccountingDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<PurchaseCategory> PurchaseCategory { get; init; }
    public DbSet<User> Users { get; init; }
    public DbSet<Purchase> Purchase { get; init; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<PurchaseCategory>().HasData(
            new PurchaseCategory { Id = 1, Name = "Продукты питания", Color = "Red" },
            new PurchaseCategory { Id = 2, Name = "Транспорт", Color = "Blue" },
            new PurchaseCategory { Id = 3, Name = "Мобильная связь", Color = "Green" },
            new PurchaseCategory { Id = 4, Name = "Интернет", Color = "Yellow" },
            new PurchaseCategory { Id = 5, Name = "Развлечения", Color = "Purple" }
        );
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Sange", Login = "CowCow", Password = "123"},
            new User { Id = 2, Name = "Polya", Login = "pol", Password = "000"}
            );
        modelBuilder.Entity<Purchase>().HasData(
            new Purchase { Id = 1, CategoryId = 2, CreatorUserId = 1, Amount = 100, Date = new DateTimeOffset(new DateTime(2024, 11, 19))},
            new Purchase { Id = 2, CategoryId = 4, CreatorUserId = 1, Amount = 350, Date = new DateTimeOffset(new DateTime(2024, 5, 19))},
            new Purchase { Id = 3, CategoryId = 5, CreatorUserId = 2, Amount = 1050, Date = new DateTimeOffset(new DateTime(2024, 10, 19))},
            new Purchase { Id = 4, CategoryId = 2, CreatorUserId = 1, Amount = 220, Date = new DateTimeOffset(new DateTime(2024, 11, 01))},
            new Purchase { Id = 5, CategoryId = 2, CreatorUserId = 1, Amount = 1050, Date = new DateTimeOffset(new DateTime(2024, 11, 30))},
            new Purchase { Id = 6, CategoryId = 3, CreatorUserId = 1, Amount = 1050, Date = new DateTimeOffset(new DateTime(2024, 12, 10))},
            new Purchase { Id = 7, CategoryId = 2, CreatorUserId = 1, Amount = 1050, Date = new DateTimeOffset(new DateTime(2024, 12, 11))}
        );

    }
}
