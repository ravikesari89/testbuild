using System.Text.RegularExpressions;

namespace SampleDiffApp.Utils
{
    public static class ValidationHelper
    {
        public static bool IsNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;
            return name.Length >= 2;
        }

        public static bool IsEmailValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
