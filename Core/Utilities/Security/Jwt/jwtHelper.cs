using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class jwtHelper : ITokenHelper
    {
        public AccesToken CreateToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
