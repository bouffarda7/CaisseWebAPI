using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CaisseWebDAL.Helpers
{
    public static class InputValidationHelper
    {

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                    RegexOptions.IgnoreCase);
        }

        public static bool IsValidUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;

            return Regex.IsMatch(username, @"\A[a-zA-Z0-9_]*\Z",
                RegexOptions.IgnoreCase);

        }

        public static bool IsValidFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
                return false;

            return Regex.IsMatch(firstName, @"\A[a-zA-Z-]*\Z",
                RegexOptions.IgnoreCase);

        }

        public static bool IsValidLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
                return false;

            return Regex.IsMatch(lastName, @"\A[a-zA-Z-]*\Z",
                RegexOptions.IgnoreCase);

        }

        public static bool IsValidBirthDate(DateTime birthday)
        {

            if (birthday == null)
                return false;

            return IsAdult(birthday);

        }


        private static bool IsAdult(DateTime birthday)
        {
            var today = DateTime.Today;
            var age = today.Year - birthday.Year;
            // Go back to the year the person was born in case of a leap year
            if (birthday.Date > today.AddYears(-age)) age--;

            return age >= 18;
        }

        public static bool IsValidPassword(string password)
        {

            if (string.IsNullOrEmpty(password))
                return false;

            return Regex.IsMatch(password, @"^(?=.*?[A-Za-z0-9])(?=.*?[#?!@$%^&*+-]).{5,}$",
                RegexOptions.IgnoreCase);
            
        }

        public static bool IsValidAddress(object address)
        {
            if (address == null)
                return false;

            Models.Adresse Adresse = (Models.Adresse)address;

            if (string.IsNullOrEmpty(Adresse.NoAdresse) || string.IsNullOrEmpty(Adresse.Rue) ||
                string.IsNullOrEmpty(Adresse.Ville) || string.IsNullOrEmpty(Adresse.CodePostal))
                return false;

            return true;
   
        }


    }
}
