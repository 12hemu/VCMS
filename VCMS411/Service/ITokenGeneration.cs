using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VCMS411.Models;

namespace VCMS411.Service
{
    public interface ITokenGeneration
    {
        //ITokenGeneration.cs
         string GenerateToken(UserCreds userCreds);
    }
}
