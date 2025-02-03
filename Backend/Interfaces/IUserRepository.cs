using Dto;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUserRepository
    {
        Task<Users> Authenticate(string userName, string passwordText);
        bool CheckUsersExits(string username);
        public LoginResDto GetUserDetailsbyCredentials(string username);
    Users GetUsersbyId(int userId);
    void Register(Users user);
    }
}
