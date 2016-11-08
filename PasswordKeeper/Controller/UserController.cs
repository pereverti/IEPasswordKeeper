using System;
using System.Linq;
using Liphsoft.Crypto.Argon2;

namespace PasswordKeeper
{
    internal class UserController
    {
        private string Salt = "j_iz>/?L*T&}ac23B)@jup{sJPH}Aa";
        private string Pepper = "f%kPk}6[;<0TEhaJKceLXgjq<4<&qP";

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="userToCreate">User to create</param>
        internal void Create(UserModel userToCreate)
        {
            using (PasswordKeeperEntities context = new PasswordKeeperEntities())
            {
                PasswordHasher hasher = new PasswordHasher();

                string passwordHash = hasher.Hash(string.Concat(Salt, userToCreate.Password, Pepper));

                User newUser = new User()
                {
                    Login = userToCreate.Login,
                    PasswordHash = passwordHash,
                    DisplayName = userToCreate.DisplayName,
                    CreationDate = userToCreate.CreationDate,
                    IsActive = userToCreate.IsActive
                };

                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update existing user
        /// </summary>
        /// <param name="userToUpdate">User to update</param>
        internal void Update(UserModel userToUpdate)
        {
            PasswordHasher hasher = new PasswordHasher();

            string passwordHash = hasher.Hash(string.Concat(Salt, userToUpdate.Password, Pepper));

            using (PasswordKeeperEntities context = new PasswordKeeperEntities())
            {
                User currentUser = GetUser(context, userToUpdate.Id);

                currentUser.PasswordHash = passwordHash;
                currentUser.DisplayName = userToUpdate.DisplayName;

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="userId">User id</param>
        internal void Delete(int userId)
        {
            using (PasswordKeeperEntities context = new PasswordKeeperEntities())
            {
                User userToDelete = GetUser(context, userId);

                userToDelete.IsActive = false;

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Get a user
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="password">Password</param>
        /// <returns>The uses which matches with the login/password</returns>
        internal UserModel GetUser(string login, string password)
        {
            UserModel user = null;

            using (PasswordKeeperEntities context = new PasswordKeeperEntities())
            {
                User currentUser = (from usr in context.Users
                                    where usr.Login.ToLower().Equals(login.ToLower()) && usr.IsActive
                                    select usr).FirstOrDefault();

                PasswordHasher hasher = new PasswordHasher();

                if (currentUser != null && hasher.Verify(currentUser.PasswordHash, string.Concat(Salt, password, Pepper)))
                {
                    user = new UserModel()
                    {
                        Id = currentUser.Id,
                        Login = currentUser.Login,
                        Password = password,
                        DisplayName = currentUser.DisplayName,
                        IsActive = currentUser.IsActive,
                        CreationDate = currentUser.CreationDate
                    };
                }
            }

            return user;
        }

        /// <summary>
        /// Count how much login exist for a given login
        /// </summary>
        /// <param name="login">User login to control</param>
        /// <returns>Occurs of the login in database</returns>
        internal int GetUserCount(string login)
        {
            using (PasswordKeeperEntities context = new PasswordKeeperEntities())
            {
                return (from usr in context.Users
                                    where usr.Login.ToLower().Equals(login.ToLower()) && usr.IsActive
                                    select usr).Count();
            }
        }

        /// <summary>
        /// Get a user from database
        /// </summary>
        /// <param name="ctx">Entity context</param>
        /// <param name="passwordId">Id of the user</param>
        /// <returns>The user matching with the id</returns>
        private User GetUser(PasswordKeeperEntities ctx, int usrId)
        {
            return (from user in ctx.Users
                    where user.Id == usrId
                    select user).First();
        }
    }
}
