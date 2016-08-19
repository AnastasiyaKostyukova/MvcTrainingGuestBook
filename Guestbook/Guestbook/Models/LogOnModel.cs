using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Guestbook.Models
{
  public class LogOnModel
  {
    [Required]
    [Display(Name = "User name")]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Required]
    [Display(Name = "Email")]
    [MinLength(5, ErrorMessage = "Must be more then 5")]
    public string Email { get; set; }

    [Required]
    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
    public string ConfirmPassword { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
  }

  
}