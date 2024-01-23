using System.Data.Entity;
using System.Diagnostics;
using aspBattleArena.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace aspBattleArena.Data;

public static class DbInitializer
{

    public static void Initialize(IServiceProvider serviceProvider)
    {
        
        using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            if (context.Bosses.Any())
            {
                return;
            }
            context.Bosses.Add(new Boss
            {
                  Age = 81, FirstName = "Kenichi", LastName = "Shinoda", Nationality = Nationality.Japanese,
            });
            context.SaveChanges();

            context.Organizations.Add(new Organization
            {
                Boss = context.Bosses.FirstOrDefault(b => b.BossId == 1), CountryOfOrigin = "Japan", Name = "Yakudza",
                
            });
            context.SaveChanges();
            context.GangMembers.AddRange(new GangMember
                {
                    FirstName = "Yui", LastName = "Nakamura", Endurance = 3, Intelligence = 5, Luck = 2,
                    Nationality = Nationality.Japanese,
                    Organization = context.Organizations.FirstOrDefault(o => o.Name == "Yakudza"), Strength = 10
                },
                new GangMember
                {
                    FirstName = "Akira", LastName = "Tanaka", Endurance = 5, Intelligence = 4,
                    Luck = 6, Strength = 5, Nationality = Nationality.Japanese,
                    Organization = context.Organizations.FirstOrDefault(o => o.Name == "Yakudza")
                });
            
            context.SaveChanges();
            context.Bases.Add(new Base
            {
                Adress = "Łobzowska 36, 31-139, Kraków", Name = "Pierogarnia",
                Organization = context.Organizations.FirstOrDefault(o => o.Name == "Yakudza")
            });
            context.SaveChanges();
        }

    }
}