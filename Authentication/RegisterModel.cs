using System;
using System.ComponentModel.DataAnnotations;

namespace AuthAuthenticationApi.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email name is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password name is required")]
        public string Password { get; set; }


    }
}
