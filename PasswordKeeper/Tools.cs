using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;

namespace PasswordKeeper
{
    public static class Tools
    {
        public enum PasswordAction // TEST
        {
            Create,
            Edit
        }

        internal enum TypeField
        {
            Login = 1,
            Password = 2
        }

        internal static int? IdCurrentPassword { get; set; }

        private static readonly Collection<string> LoginControlNames = new Collection<string>()
        {
            "login",
            "mail",
            "name"
        };

        private static readonly Collection<string> PasswordControlNames = new Collection<string>()
        {
            "password",
            "pass"
        };

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

        internal static string AESEncryption(string plain, string key, string salt, Pkcs7Padding padding)
        {
            BCEngine bcEngine = new BCEngine(new AesEngine(), Encoding.UTF8);
            bcEngine.SetPadding(padding);
            return bcEngine.Encrypt(plain, key);
        }

        internal static string AESDecryption(string cipher, string key, string salt, Pkcs7Padding padding)
        {
            BCEngine bcEngine = new BCEngine(new AesEngine(), Encoding.UTF8);
            bcEngine.SetPadding(padding);
            return bcEngine.Decrypt(cipher, key);
        }

        internal static bool IsLogin(string id)
        {
            return LoginControlNames.Any(lcn => id.ToLower().Contains(lcn));
        }

        internal static bool IsPassword(string id)
        {
            return PasswordControlNames.Any(pcn => id.ToLower().Contains(pcn));
        }

        internal static string GetMacAddress()
        {
            return (from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
        }
    }
}
