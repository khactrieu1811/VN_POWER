using Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Website.Services
{
    public interface IJwtHandler
    {
        JsonWebToken Create(string username);
    }
}
