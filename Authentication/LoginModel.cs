using System;
using System.ComponentModel.DataAnnotations;

namespace AuthAuthenticationApi.Authentication
{
	public class LoginModel
	{
        [Required(ErrorMessage = "User name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password name is required")]
        public string Password { get; set; }
    }
}

