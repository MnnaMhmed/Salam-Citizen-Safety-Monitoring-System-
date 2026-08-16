using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Salam_Application.DTOs;
using Salam_Domain.Entities;
using Salam_Domain.Interfaces;
using BCrypt.Net;
using Salam_Application.Services_Interfces;
namespace Salam_Application.Services
{
    public class AuthService:IAuthService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITokenService tokenService;

      
        public AuthService(IUnitOfWork _unitOfWork, TokenService _tokenService)
        {
            unitOfWork = _unitOfWork;
            tokenService = _tokenService;

        }

        public async Task <bool>Register( RegisterDto RDto)
        {



            var users = await unitOfWork.Users.GetAllAsync();
            var user = users.FirstOrDefault(u => u.NationalId == RDto.NationalId);

            if (user != null)
                return false;
          
                var newuser = new User
                {
                    FullName = RDto.FullName,
                    NationalId = RDto.NationalId,
                    PhoneNumber = RDto.PhoneNumber,
                    BloodType = RDto.BloodType,
                    AccountType = RDto.AccountType,
                    IsDeaf = RDto.IsDeaf,
                    Password = BCrypt.Net.BCrypt.HashPassword(RDto.Password)
                };
                await unitOfWork.Users.AddAsync(newuser);
                await unitOfWork.SaveChangesAsync();
                return true;

            


        }
        public async Task<string> Login(LoginDto LDto )
        {
            var users = await unitOfWork.Users.GetAllAsync();
            var user = users.FirstOrDefault(u => u.NationalId == LDto.NationalId);
            if (user == null)
            {
                return "User Not Found";
            }

            bool passvaild = BCrypt.Net.BCrypt.Verify(LDto.Password , user.Password);

            if (!passvaild)
                return "Password Isnot Correct Please Try Again";
            var token = tokenService.CreateToken(user);
            return token;


        }

    }








}
