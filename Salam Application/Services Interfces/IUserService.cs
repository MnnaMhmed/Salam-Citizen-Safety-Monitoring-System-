using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Application.DTOs;
using Salam_Domain.Entities;

namespace Salam_Domain.Interfaces
{
    public interface IUserService
    {
        

            Task<IEnumerable<User>> GetAllUsersAsync();
            Task<User> GetUserByIdAsync(int id);
            Task AddUserAsync(UserDto userdto);
        Task UpdateUserAsync(int id, User user);
        Task DeleteUserAsync(int id);

    }
}
