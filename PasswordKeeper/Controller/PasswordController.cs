using System.Collections.Generic;
using System.Linq;

namespace PasswordKeeper
{
    internal class PasswordController
    {
        /// <summary>
        /// Create a new password
        /// </summary>
        /// <param name="pwdToCreate">Password to create</param>
        internal void Create(PasswordModel pwdToCreate)
        {
            using (PasswordKeeperEntities context = new PasswordKeeperEntities())
            {
                Password newPwd = new Password()
                {
                    Login = pwdToCreate.Login,
                    Password1 = pwdToCreate.Password,
                    DisplayName = pwdToCreate.DisplayName,
                    Url = pwdToCreate.Url,
                    Notes = pwdToCreate.Notes,
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
            using (PasswordKeeperEntities context = new PasswordKeeperEntities())
            {
                Password pass = GetPassword(context, pwdToUpdate.Id);

                pass.DisplayName = pwdToUpdate.DisplayName;
                pass.Login = pwdToUpdate.Login;
                pass.Password1 = pwdToUpdate.Password;
                pass.Url = pwdToUpdate.Url;
                pass.Notes = pwdToUpdate.Notes;

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

                foreach (Password pwd in pwds)
                {
                    passwords.Add(new PasswordModel()
                    {
                        Id = pwd.Id,
                        DisplayName = pwd.DisplayName,
                        Login = pwd.Login,
                        Password = pwd.Password1,
                        Url = pwd.Url,
                        Notes = pwd.Notes,
                        CreationDate = pwd.CreationDate,
                        IsActive = pwd.IsActive,
                        UserId = pwd.UserId
                    });
                }
            }

            return passwords;
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
