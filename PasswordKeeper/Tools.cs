using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKeeper
{
    public class Tools
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
    }
}
