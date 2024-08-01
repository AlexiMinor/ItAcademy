using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ItAcademy.MVC.Models;

public class UserRegisterModel
{
    [Required]
    [Remote("CheckEmail", "User", HttpMethod = "POST")]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    
    [Compare(nameof(Password))]
    public string PasswordConfirmation { get; set; }
}