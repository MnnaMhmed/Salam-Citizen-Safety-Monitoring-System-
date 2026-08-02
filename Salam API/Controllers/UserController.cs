using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Salam_Application.DTOs;
using Salam_Application.Services;
using Salam_Domain.Entities;
using Salam_Domain.Interfaces;
using Salam_Infrastructure.Repositories;
namespace Salam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserService userService;
        public UserController(IUnitOfWork _unitOfWork, IUserService _userService)
        {
            unitOfWork = _unitOfWork;
            userService = _userService;
        }


        [HttpGet("Get_Users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsersAsync();

            return (Ok(users));

        }
        [HttpGet("Get_User_By_Id")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return (NotFound());

            }
            return (Ok(user));

        }
        [HttpPost("Add_User")]
        public async Task<IActionResult> AddUser(UserDto userdto)
        {
            if (userdto != null)
            {
                await userService.AddUserAsync(userdto);
                return (Ok());
            }
            else
                return (BadRequest("Please enter a vaild user"));

        }

        [HttpDelete("Delete_User")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            var user = await userService.GetUserByIdAsync(id);
            if (user != null)
            {
                await userService.DeleteUserAsync(id);
                return (Ok());
            }
            else { return (NotFound("This User Isnot in the database")); }
        }
        [HttpPut("Update_User")]
        public async Task<IActionResult> UpdateUser(int id, User updatedUser)
        {

            if (updatedUser == null || id == null)
            {
                return (BadRequest("Please enter aild data"));
            }

            var u = await userService.GetUserByIdAsync(id);
            if (u != null) {
                await userService.UpdateUserAsync(id, updatedUser);

                return (Ok());
            }
        
            else
                return (NotFound("Cannot find This User!"));

        }

    }


}


