using MogobariWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MogobariWebAPI.BL.Interface
{
    public interface ITokenManager
    {
        RefreshTokenForCustomer GenerateRefreshToken();
        string GenerateAccessToken(int userId);
        void GenerateHash(String Password, out byte[] PasswordHash, out byte[] PasswordSalt);
        bool ValidateHash(string password, byte[] passwordhash, byte[] passwordsalt);
    }
}
