using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VCMS411.Models;

namespace VCMS411.Service
{
    public class UserService : IUserService
    {
        private readonly VCMS_81411Context _vCMS_81411Context;
        public UserService(VCMS_81411Context vCMS_81411Context)
        {
            _vCMS_81411Context = vCMS_81411Context;
        }
        public UserDetails AddUser(UserDetails user)
        {
            try
            {
                _vCMS_81411Context.UserDetails.Add(user);
                _vCMS_81411Context.SaveChanges(); return user; }
            catch (Exception) { throw; }
        }

        public List<UserDetails> GetAllUser()
        {
            return _vCMS_81411Context.UserDetails.ToList();
        }

    }
}
