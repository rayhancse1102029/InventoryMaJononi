using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InventoryMaJononi.Data.Entity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;

namespace InventoryMaJononi.Models.AccountViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "maximum 20 char and minimum 3 char")]
        [DisplayName("First Name")]
        public string firstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "maximum 20 char and minimum 3 char")]
        [DisplayName("Last Name")]
        public string lastName { get; set; }


        [Required]
        [DisplayName("Image")]
        public byte[] img { get; set; }

        [Required]
        [StringLength(20)]
        public string phone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        public IEnumerable<ApplicationUser> allUsers { get; set; } 

    }
}
