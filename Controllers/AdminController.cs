using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AuthAuthenticationApi.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthAuthenticationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)] // Ensure only admins can access this controller
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AdminController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound(new Response<object> { Status = "Error", Message = "User not found" });
            }

            return Ok(new Response<object> { Status = "Success", Data = user });
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = userManager.Users;
            return Ok(new Response<object> { Status = "Success", Data = users });
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound(new Response<object> { Status = "Error", Message = "User not found" });
            }

            var result = await userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response<object> { Status = "Error", Message = "Failed to delete user" });
            }

            return Ok(new Response<object> { Status = "Success", Message = "User deleted successfully" });
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserModel model)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound(new Response<object> { Status = "Error", Message = "User not found" });
            }

            // Update the user properties based on the model
            user.Email = model.Email;
            user.UserName = model.Username;

            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response<object> { Status = "Error", Message = "Failed to update user" });
            }

            return Ok(new Response<object> { Status = "Success", Message = "User updated successfully" });
        }
    }
}
