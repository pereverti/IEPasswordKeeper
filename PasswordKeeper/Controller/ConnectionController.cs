using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace PasswordKeeper
{
    internal class ConnectionController
    {
        private const string Salt = "0M@>N:8gK*j'X!iI[.@d3m!dQ44m2o";
        private const string Pepper = "ylP$ENY_%YYM,[aS5g{qn}rh{=*2m4";
        private const string SaltKey = "p?c4eqx!)~sJ/ax&x'UQf^fr>1Cl*.";
        private const string PepperKey = "$A?^T~:Qt:VKyWqa@E2:/1*Ky%xnN9";

        private readonly string Key256Bits;

        internal ConnectionController(string key)
        {
            Key256Bits = Get256BitsKey(key);
        }

        /// <summary>
        /// Temporarily store the current connection
        /// </summary>
        /// <param name="tmpConnectionToSet">Current connection to store</param>
        internal void Set(ConnectionModel tmpConnectionToSet)
        {
            BCEngine engine = new BCEngine(new AesEngine(), Encoding.UTF8);
            engine.SetPadding(new Pkcs7Padding());

            string encComputerMacAddress = engine.Encrypt(string.Concat(Salt, tmpConnectionToSet.MachineMacAddress, Pepper), Key256Bits);
            string encComputerName = engine.Encrypt(string.Concat(Salt, tmpConnectionToSet.MachineName, Pepper), Key256Bits);
            string encComputerUserName = engine.Encrypt(string.Concat(Salt, tmpConnectionToSet.MachineUserName, Pepper), Key256Bits);

            using (PasswordKeeperEntities context = new PasswordKeeperEntities())
            {
                // Delete any previous row which match
                List<ConnectionTemp> existingConnections = (from conn in context.ConnectionTemps
                                                            where conn.ComputerMacAddress.Equals(encComputerMacAddress) &&
                                                                conn.ComputerName.Equals(encComputerName) &&
                                                                conn.ComputerUserName.Equals(encComputerUserName)
                                                            select conn).ToList();

                if (existingConnections.Count > 0)
                    context.ConnectionTemps.RemoveRange(existingConnections);

                // Add the current connection
                ConnectionTemp newConnTmp = new ConnectionTemp()
                {
                    IdUser = tmpConnectionToSet.UserId,
                    ComputerMacAddress = encComputerMacAddress,
                    ComputerName = encComputerName,
                    ComputerUserName = encComputerUserName,
                    ConnexionDate = tmpConnectionToSet.ConnectionDate
                };

                context.ConnectionTemps.Add(newConnTmp);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a specify connection
        /// </summary>
        /// <param name="tmpConnectionToSet">connection to delete</param>
        internal void DeleteConnection(ConnectionModel tmpConnectionToSet)
        {
            BCEngine engine = new BCEngine(new AesEngine(), Encoding.UTF8);
            engine.SetPadding(new Pkcs7Padding());

            string encComputerMacAddress = engine.Encrypt(string.Concat(Salt, tmpConnectionToSet.MachineMacAddress, Pepper), Key256Bits);
            string encComputerName = engine.Encrypt(string.Concat(Salt, tmpConnectionToSet.MachineName, Pepper), Key256Bits);
            string encComputerUserName = engine.Encrypt(string.Concat(Salt, tmpConnectionToSet.MachineUserName, Pepper), Key256Bits);

            using (PasswordKeeperEntities context = new PasswordKeeperEntities())
            {
                // Delete any previous row which match
                List<ConnectionTemp> existingConnections = (from conn in context.ConnectionTemps
                                                            where conn.ComputerMacAddress.Equals(encComputerMacAddress) &&
                                                                conn.ComputerName.Equals(encComputerName) &&
                                                                conn.ComputerUserName.Equals(encComputerUserName)
                                                            select conn).ToList();

                if (existingConnections.Count > 0)
                {
                    context.ConnectionTemps.RemoveRange(existingConnections);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Clean all connections
        /// </summary>
        internal void SwipeOldConnections()
        {
            using (PasswordKeeperEntities context = new PasswordKeeperEntities())
            {
                // Delete any previous row older than an hour
                List<ConnectionTemp> existingConnections = (from conn in context.ConnectionTemps
                                                            where DbFunctions.AddHours(conn.ConnexionDate, 1) < DateTime.Now
                                                            select conn).ToList();

                if (existingConnections.Count > 0)
                {
                    context.ConnectionTemps.RemoveRange(existingConnections);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Get the last user id for the given connection details
        /// </summary>
        /// <param name="tmpConnection">Connection data</param>
        /// <returns>The user id</returns>
        internal int? GetConnectionTempUserId(ConnectionModel tmpConnection)
        {
            BCEngine engine = new BCEngine(new AesEngine(), Encoding.UTF8);
            engine.SetPadding(new Pkcs7Padding());

            string encComputerMacAddress = engine.Encrypt(string.Concat(Salt, tmpConnection.MachineMacAddress, Pepper), Key256Bits);
            string encComputerName = engine.Encrypt(string.Concat(Salt, tmpConnection.MachineName, Pepper), Key256Bits);
            string encComputerUserName = engine.Encrypt(string.Concat(Salt, tmpConnection.MachineUserName, Pepper), Key256Bits);

            using (PasswordKeeperEntities context = new PasswordKeeperEntities())
            {
                int usrIdLogin = (from conn in context.ConnectionTemps
                                  where conn.ComputerMacAddress.Equals(encComputerMacAddress) &&
                                     conn.ComputerName.Equals(encComputerName) &&
                                     conn.ComputerUserName.Equals(encComputerUserName)
                                  select conn.IdUser).FirstOrDefault();

                return usrIdLogin == 0 ? new int?() : usrIdLogin;
            }
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
    }
}