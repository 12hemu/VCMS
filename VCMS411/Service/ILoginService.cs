using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VCMS411.Models;

namespace VCMS411.Service
{
   public interface ILoginService
    {
        UserCreds Login(UserCreds userCreds);
       UserCreds Register( UserDetails user);
    }
}
