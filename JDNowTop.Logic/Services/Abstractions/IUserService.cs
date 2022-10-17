using JDNowTop.Data.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDNowTop.Logic.Services.Abstractions
{
    public interface IUserService
    {
        Task<bool> SignUp(string username, string password);
        Task<JwtSecurityToken?> LogIn(string username, string password);
    }
}
