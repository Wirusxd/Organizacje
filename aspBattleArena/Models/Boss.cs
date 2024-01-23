using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using aspBattleArena.Controllers;
using aspBattleArena.Data;
using aspBattleArena.Views.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;

namespace aspBattleArena.Models;

public class Boss
{
    [Key]
    public int BossId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Nationality Nationality { get; set; }
    public string OrganizationName { get; set; }
    
    public  IList<Organization> Organizations { get; set; }
    
  
    public Boss()
    {
        
        
    }

}