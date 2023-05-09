using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VCMS411.Models;

namespace VCMS411.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUserService _userService;
        private readonly ITokenGeneration _tokenGeneration;
        public LoginService(IUserService userService, ITokenGeneration tokenGeneration)
        {
         _userService = userService;
            _tokenGeneration = tokenGeneration;
        }
        public UserCreds Login(UserCreds userCreds)
        { var user = _userService.GetAllUser().FirstOrDefault(u =>u.UserName == userCreds.UserName);
            if (user != null) { if (user.UserPassword != userCreds.Password)
                { return null; }
                userCreds.Password = user.UserPassword;
                userCreds.Token = _tokenGeneration.GenerateToken(userCreds);
                return userCreds; }
            return null; }

        public UserCreds Register(UserDetails user)
        {
            UserDetails userDetails = null;
            var users = _userService.GetAllUser().FirstOrDefault(u => u.UserName == user.UserName);
            if (users == null)
            {
                userDetails = _userService.AddUser(user);
            }


            if (userDetails != null)
            {
                return new UserCreds
                {
                    UserName = user.UserName,
                    Token = _tokenGeneration.GenerateToken(new UserCreds { UserName = user.UserName })
                };
            }
            return null;
        }
    }
}
