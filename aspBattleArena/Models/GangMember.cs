using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspBattleArena.Models;

public class GangMember
{
    [Key]
    public int MemberId { get; set; }
    [Required(ErrorMessage = "Cz�onek musi mie� imi�")]
    [Display(Name="Imi�")]
    [RegularExpression(@"^[a-zA-Z]*$",ErrorMessage = "Imi� mo�e zawiera� tylko litery")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Cz�onek musi mie� nazwisko")]
    [Display(Name="Nazwisko")]
    [RegularExpression(@"^[a-zA-Z]*$",ErrorMessage = "Nazwisko mo�e zawiera� tylko litery")]
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