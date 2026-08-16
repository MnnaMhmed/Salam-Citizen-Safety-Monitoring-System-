
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Application.DTOs;

namespace Salam_Application.Services_Interfces
{
    public interface IAuthService
    {

        public  Task <bool>Register(RegisterDto RDto);

        public  Task<string> Login(LoginDto LDto);

    }
}
