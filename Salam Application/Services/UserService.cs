using Salam_Domain.Interfaces;
using Salam_Domain.Interfaces;
using Salam_Domain.Entities;
using Salam_Application.DTOs;

namespace Salam_Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task AddUserAsync(UserDto userdto)
        {

            var user = new User
            {
                FullName = userdto.FullName,
                NationalId = userdto.NationalId,
                PhoneNumber = userdto.PhoneNumber,
                BloodType = userdto.BloodType,
                AccountType = userdto.AccountType,
                IsDeaf = userdto.IsDeaf,
                Password = userdto.Password
            };
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user == null)
                return;

            _unitOfWork.Users.DeleteAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(int id, User updatedUser)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user == null)
                return;

            user.FullName = updatedUser.FullName;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.IsDeaf=updatedUser.IsDeaf;
            user.BloodType= updatedUser.BloodType;
            user.AccountType = updatedUser.AccountType;

            _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}