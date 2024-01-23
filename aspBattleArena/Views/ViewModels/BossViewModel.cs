using System.ComponentModel.DataAnnotations;
using aspBattleArena.Models;
using Azure.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace aspBattleArena.Views.ViewModels;

public class BossViewModel
{
   public  int BossId { get; set; }
    [Required(ErrorMessage = "Szef musi mie� imi�")]
    [Display(Name="Imi�")]
    [RegularExpression(@"^[a-zA-Z]*$",ErrorMessage = "Imi� mo�e zawiera� tylko litery")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Szef musi mie� nazwisko")]
    [Display(Name="Nazwisko")]
    [RegularExpression(@"^[a-zA-Z]*$",ErrorMessage = "Nazwisko mo�e zawiera� tylko litery")]
    public string LastName { get; set; }
    
    [Display(Name="Wiek")]
    public int Age { get; set; }
    [Display(Name = "Narodowo��")]
    public Nationality Nationality { get; set; }
    [Display(Name = "Organizacja")]
    public  string Organization { get; set; }
    public Organization Organizations { get; set; }

}