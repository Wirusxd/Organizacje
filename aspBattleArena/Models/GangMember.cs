using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspBattleArena.Models;

public class GangMember
{
    [Key]
    public int MemberId { get; set; }
    [Required(ErrorMessage = "Cz³onek musi mieæ imiê")]
    [Display(Name="Imiê")]
    [RegularExpression(@"^[a-zA-Z]*$",ErrorMessage = "Imiê mo¿e zawieraæ tylko litery")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Cz³onek musi mieæ nazwisko")]
    [Display(Name="Nazwisko")]
    [RegularExpression(@"^[a-zA-Z]*$",ErrorMessage = "Nazwisko mo¿e zawieraæ tylko litery")]
    public string LastName { get; set; }
    public  Nationality Nationality { get; set; }
    public Organization Organization { get; set; }
    public int Strength { get; set; }
    public int Endurance { get; set; }
    public int Intelligence { get; set; }
    public int Luck { get; set; }

    public GangMember()
    {
        
    }
}