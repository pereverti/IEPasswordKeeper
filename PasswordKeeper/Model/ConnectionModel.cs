using System;

namespace PasswordKeeper
{
    internal class ConnectionModel
    {
        internal int UserId { get; set; }
        internal string MachineName { get; set; }
        internal string MachineMacAddress { get; set; }
        internal string MachineUserName { get; set; }
        internal DateTime ConnectionDate { get; set; }
    }
}
