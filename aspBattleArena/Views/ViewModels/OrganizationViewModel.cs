using System.ComponentModel.DataAnnotations;
using aspBattleArena.Models;

namespace aspBattleArena.Views.ViewModels;

public class OrganizationViewModel
{
    public int OrganizationId { get; set; }
    [Required(ErrorMessage = "Wpisz nazwê bazy" )]
    [Display(Name = "Nazwa")]
    [RegularExpression(@"^[A-Z]+[a-zA-Z]*$",ErrorMessage = "Nazwa mo¿e zawieraæ tylko litery")]
    public string Name { get; set; }
    [Display(Name = "Kraj pochodzenia")]
    public string CountryOfOrigin { get; set; }
    [Display(Name = "Szef")]
    public int BossID { get; set; }
    public  Boss Boss { get; set; }
    

    
}