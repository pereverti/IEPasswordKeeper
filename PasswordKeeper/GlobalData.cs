using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace PasswordKeeper
{
    [ComVisible(false)]
    public class GlobalData
    {
        private static GlobalData instance = null;
        private SharedData optionPageData;

        private const int Login = 0;
        private const int Password = 1;

        public GlobalData()
        {
            //System.Diagnostics.Debugger.Break();
            this.optionPageData = new SharedData("PasswordKeeperOptions", 512, 10);

            this.optionPageData[Login] = string.Empty;
            this.optionPageData[Password] = string.Empty;
        }

        private void ConnectOptions()
        {
            if (this.optionPageData == null)
            {
                this.optionPageData = new SharedData("PasswordKeeperOptions", 512, 10);

                this.optionPageData[Login] = string.Empty;
                this.optionPageData[Password] = string.Empty;
            }
        }

        public static GlobalData Instance
        {
            get
            {
                if (instance == null)
                    instance = new GlobalData();
                return instance;
            }
        }

        
        public void RefreshOptions(MyIEAdvancedBar1 module)
        {
            lock (instance)
            {
                ConnectOptions();

                module.OptionLogin = optionPageData[Login].ToString();
                module.OptionPassword = optionPageData[Password].ToString();
            }
        }

        public void UpdateOptions(MyIEAdvancedBar1 module)
        {
            lock (instance)
            {
                ConnectOptions();

                this.optionPageData[Login] = module.OptionLogin;
                this.optionPageData[Password] = module.OptionPassword;
            }
        }
    }
}

