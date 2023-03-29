
using System;
using System.Collections.Generic;
using Website.Models;


namespace Website.Services
{
    public interface IAccountService
    {
        void SignUp(string username, string password);
     
        JsonWebToken SignIn(string username, string password);
        JsonWebToken RefreshAccessToken(string token);
        void RevokeRefreshToken(string token);
       
    }
}