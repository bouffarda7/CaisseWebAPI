using JWTUtils;
using JWTUtils.Helpers;
using JWTUtils.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CaisseWebAPI.Helpers
{
    public static class TokenHelper
    {
        public static string CreateToken(string name, string email, string username, string role)
        {
            var tokenFactory = new JwtTokenFactory(new Base64UrlUtil(true), new RsaSigningUtil("caissekey.pem", "caissekeyp.pem", HashFunctionType.Sha256));

            return tokenFactory.CreateToken("CaisseWebAPI","CaisseWebApiAuth", name, email, 30, username, new List<string>() { role });

        }

        public static bool ValidateToken(string token)
        {
            try
            {
                var jwtValidator = new JwtValidator(new RsaSigningUtil("caissekey.pem", "caissekeyp.pem", HashFunctionType.Sha256), new Base64UrlUtil(true));

                JwtToken tokenToValidate = jwtValidator.ExtractToken(token);

                return jwtValidator.ValidateSignature(token) && ValidateNotExpired(tokenToValidate.Payload.Expire);
            }
            catch (Exception e)
            {
                return false;
            }


        }

        public static bool ValidateNotExpired(string ExpirationDate)
        {
            return DateTime.Now < DateTime.Parse(ExpirationDate, CultureInfo.CurrentCulture);
        }



    }
}
