using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PasswordKeeper
{
    public static class Tools
    {
        public enum PasswordAction
        {
            Create,
            Edit
        }

        internal const string LblButtonRegister = "Register";
        internal const string lblButtonConnect = "Connect";
        internal const string lblButtonUpdate = "Update";
        internal const string LblLinkButtonRegister = "Register";
        internal const string LblLinkButtonCancel = "Cancel";

        internal const int WM_UPDATE_OPTIONS = (0x400 + 3000);

        private static bool domainInvalid;

        internal static bool IsValidEmail(string email)
        {
            domainInvalid = false;

            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (domainInvalid)
                return false;

            // Return true if the email string is in valid e-mail format.
            try
            {
                return Regex.IsMatch(email,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private static string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;

            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                domainInvalid = true;
            }

            return match.Groups[1].Value + domainName;
        }
    }
}
