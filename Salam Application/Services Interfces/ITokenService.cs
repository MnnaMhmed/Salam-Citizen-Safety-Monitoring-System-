using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salam_Domain.Entities;

namespace Salam_Application.Services_Interfces
{
    public interface ITokenService
    {

        string CreateToken(User user);
    }
}
