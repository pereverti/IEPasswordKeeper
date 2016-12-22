using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordKeeper
{
    internal class PasswordController
    {
        private const string Salt = "r6U+U]Do>vGyLkLg?`()M726zZ{'Vj";
        private const string Pepper = "|@EKjLU?F./#1:N8!bG7A$AttqD!2I";
        private const string SaltKey = "~=g^QrT);zC19[3}`9Wy~oj!5eIxpF";
        private const string PepperKey = "%+&j?c;o%Gy&cWRxYvIghdZr!#*/Jf";

        private readonly string Key256Bits;

        internal PasswordController()
        {
        }

        internal PasswordController(string key)
        {
            Key256Bits = Get256BitsKey(key);
        }

        /// <summary>
        /// Create a new password
        /// </summary>
        /// <param name="pwdToCreate">Password to create</param>
        internal void Create(PasswordModel pwdToCreate)
        {
            BCEngine engine = new BCEngine(new AesEngine(), Encoding.UTF8);
            engine.SetPadding(new Pkcs7Padding());

            using (PasswordKeeperEntities context = new PasswordKeeperEntities())
            {
                Password newPwd = new Password()
                {
                    Login = engine.Encrypt(string.Concat(Salt, pwdToCreate.Login, Pepper), Key256Bits),
                    Password1 = engine.Encrypt(string.Concat(Salt, pwdToCreate.Password, Pepper), Key256Bits),
                    DisplayName = pwdToCreate.DisplayName,
                    Url = engine.Encrypt(string.Concat(Salt, pwdToCreate.Url, Pepper), Key256Bits),
                    Notes = engine.Encrypt(string.Concat(Salt, pwdToCreate.Notes, Pepper), Key256Bits),
                    CreationDate = pwdToCreate.CreationDate,
                    IsActive = pwdToCreate.IsActive,
                    UserId = pwdToCreate.UserId
                };

                context.Passwords.Add(newPwd);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update a password
        /// </summary>
        /// <param name="pwdToUpdate">Password to update</param>
        internal void Update(PasswordModel pwdToUpdate)
        {
            BCEngine engine = new BCEngine(new AesEngine(), Encoding.UTF8);
            engine.SetPadding(new Pkcs7Padding());

            using (PasswordKeeperEntities context = new PasswordKeeperEntities())
            {
                Password pass = GetPassword(context, pwdToUpdate.Id);

                pass.DisplayName = pwdToUpdate.DisplayName;
                pass.Login = engine.Encrypt(string.Concat(Salt, pwdToUpdate.Login, Pepper), Key256Bits);
                pass.Password1 = engine.Encrypt(string.Concat(Salt, pwdToUpdate.Password, Pepper), Key256Bits);
                pass.Url = engine.Encrypt(string.Concat(Salt, pwdToUpdate.Url, Pepper), Key256Bits);
                pass.Notes = engine.Encrypt(string.Concat(Salt, pwdToUpdate.Notes, Pepper), Key256Bits);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a password
        /// </summary>
        /// <param name="pwdId">Password id</param>
        internal void Delete(int pwdId)
        {
            using (PasswordKeeperEntities context = new PasswordKeeperEntities())
            {
                Password pass = GetPassword(context, pwdId);

                pass.IsActive = false;

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Get the whole list of passwords for a user
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>The list of active passwords</returns>
        internal List<PasswordModel> GetList(int userId)
        {
            List<PasswordModel> passwords = new List<PasswordModel>();

            using (PasswordKeeperEntities context = new PasswordKeeperEntities())
            {
                List<Password> pwds = (from pass in context.Passwords
                                       where pass.IsActive && pass.UserId == userId
                                       select pass).ToList();

                BCEngine engine = new BCEngine(new AesEngine(), Encoding.UTF8);
                engine.SetPadding(new Pkcs7Padding());

                foreach (Password pwd in pwds)
                {
                    passwords.Add(new PasswordModel()
                    {
                        Id = pwd.Id,
                        DisplayName = pwd.DisplayName,
                        Login = GetDecryptedString(engine, pwd.Login),
                        Password = GetDecryptedString(engine, pwd.Password1),
                        Url = GetDecryptedString(engine, pwd.Url),
                        Notes = GetDecryptedString(engine, pwd.Notes),
                        CreationDate = pwd.CreationDate,
                        IsActive = pwd.IsActive,
                        UserId = pwd.UserId
                    });
                }
            }

            return passwords;
        }

        /// <summary>
        /// Build a 256 bits string from the key (user login), a salt and a pepper string
        /// </summary>
        /// <param name="key">User key (login)</param>
        /// <returns>256 bits key string</returns>
        private string Get256BitsKey(string key)
        {
            string saltedKey = string.Concat(SaltKey, key, PepperKey);
            int middle = saltedKey.Length / 2;

            string left = saltedKey.Remove(middle);

            left = left.Remove(0, left.Length - 16);

            string right = saltedKey.Substring(middle, saltedKey.Length - middle);

            right = right.Substring(0, 16);

            return string.Concat(left, right);
        }

        /// <summary>
        /// Decrypt cipher string and remove salt and pepper
        /// </summary>
        /// <param name="engine">Cipher engine</param>
        /// <param name="cipher">Cipher text</param>
        /// <returns>Decrypted string</returns>
        private string GetDecryptedString(BCEngine engine, string cipher)
        {
            string saltedString = engine.Decrypt(cipher, Key256Bits);

            return saltedString.Replace(Salt, string.Empty).Replace(Pepper, string.Empty);
        }

        /// <summary>
        /// Get a password from database
        /// </summary>
        /// <param name="ctx">Entity context</param>
        /// <param name="passwordId">Id of the password</param>
        /// <returns>The password matching with the id</returns>
        private Password GetPassword(PasswordKeeperEntities ctx, int passwordId)
        {
            return (from pwd in ctx.Passwords
                    where pwd.Id == passwordId
                    select pwd).First();
        }
    }
}
