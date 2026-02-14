using BancoSimplificado.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoSimplificado.Api.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Transaction>()
            .HasOne(t => t.SenderUser)
            .WithMany(u => u.Transactions)
            .HasForeignKey(t => t.SenderUserCpf);

        base.OnModelCreating(builder);
    }
}