using System;
using System.Collections.Generic;
using System.Text;

namespace CaisseWebDAL.Helpers
{
    public static class PasswordHelper
    {

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public static string HashPassword(string passwordToHash)
        {
            return BCrypt.Net.BCrypt.HashPassword(passwordToHash);
        }
    }
}
