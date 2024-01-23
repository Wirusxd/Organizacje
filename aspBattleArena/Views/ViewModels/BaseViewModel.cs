using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using aspBattleArena.Models;
using Azure.Core;

namespace aspBattleArena.Views.ViewModels;

public class BaseViewModel
{
    [Required]
    [Display(Name = "Nazwa")]
    [RegularExpression(@"^[A-Z]+[a-zA-Z]*$",ErrorMessage = "Nazwa mo¿e zawieraaæ tylko litery")]
    
    public string Nazwa{ get; set; }
    [Required]
    [Display(Name = "Adres")]
    public string Address { get; set; }
    [Display(Name = "Nazwa organizacji")]
    public string OrganizationName { get; set; }
}