using aspBattleArena.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace aspBattleArena.Data;

public class AppDbContext: IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    
    public DbSet<Boss> Bosses { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Base> Bases { get; set; }
    public DbSet<GangMember> GangMembers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Boss>().HasMany(b => b.Organizations);
        modelBuilder.Entity<Organization>().HasOne(o => o.Boss);
        modelBuilder.Entity<Organization>().HasMany(o => o.Members);
        modelBuilder.Entity<Organization>().HasMany(o => o.Bases);
        modelBuilder.Entity<Base>().HasOne(b => b.Organization);
        modelBuilder.Entity<GangMember>().HasOne(g => g.Organization);

        
    } 
}