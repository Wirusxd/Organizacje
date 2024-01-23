using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspBattleArena.Models;

public class Organization
{
    [Key]
    public int OgranizationId { get; set; }
    public string Name { get; set; }
    public string CountryOfOrigin { get; set; }
    public  string NameOfBoss { get; set; }
    public Boss Boss { get; set; }
    public IList<GangMember> Members { get; set; }
    public IList<Base> Bases { get; set; }

    public Organization()
    {
        Members = new List<GangMember>();
        Bases = new List<Base>();
    }
}