using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using IE = Interop.SHDocVw;
using AddinExpress.IE;

namespace PasswordKeeper
{
    /// <summary>
    /// Add-in Express for Internet Explorer Module
    /// </summary>
    [ComVisible(true), Guid("5A81FD14-034E-4B8A-9948-AB6CE47D3C55")]
    public class IEModule : ADXIEModule
    {
        public IEModule()
        {
            InitializeComponent();
            //Please write any initialization code in the OnConnect event handler
        }

        // private MyIEAdvancedBar1 PasswordKeeperModule;

        private ADXIEAdvancedBarsManager adxieAdvancedBarsManager1;
        private ADXIEAdvancedBarItem advBarItemPasswordLeftPane;
        private ADXIECommandItem cmdPasswordKeeper;
        private ADXIEHTMLDocEvents adxiehtmlDocEvents1;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem toolStripAddLogin;
        private ToolStripMenuItem toolStripAddPassword;

        public IEModule(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            //Please write any initialization code in the OnConnect event handler
        }

        #region Component Designer generated code
        /// <summary>
        /// Required by designer
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Required by designer support - do not modify
        /// the following method
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.adxieAdvancedBarsManager1 = new AddinExpress.IE.ADXIEAdvancedBarsManager(this.components);
            this.advBarItemPasswordLeftPane = new AddinExpress.IE.ADXIEAdvancedBarItem(this.components);
            this.cmdPasswordKeeper = new AddinExpress.IE.ADXIECommandItem(this.components);
            this.adxiehtmlDocEvents1 = new AddinExpress.IE.ADXIEHTMLDocEvents(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripAddLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            // 
            // adxieAdvancedBarsManager1
            // 
            this.adxieAdvancedBarsManager1.Bars.Add(this.advBarItemPasswordLeftPane);
            // 
            // advBarItemPasswordLeftPane
            // 
            this.advBarItemPasswordLeftPane.ApplyChangesForAllTabs = true;
            this.advBarItemPasswordLeftPane.BarType = "PasswordKeeper.MyIEAdvancedBar1";
            this.advBarItemPasswordLeftPane.Id = "{735574D4-000F-4945-9343-B03C6FB871B5}";
            this.advBarItemPasswordLeftPane.MenuText = "Password Keeper";
            this.advBarItemPasswordLeftPane.Shortcut = System.Windows.Forms.Shortcut.AltF12;
            this.advBarItemPasswordLeftPane.Visible = true;
            // 
            // cmdPasswordKeeper
            // 
            this.cmdPasswordKeeper.ActiveIcon = "Icons.SampleIcon2";
            this.cmdPasswordKeeper.Caption = "Password Keeper";
            this.cmdPasswordKeeper.CommandGuid = "{75235D32-8F17-4E67-9964-2890A4D6A04E}";
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAddLogin,
            this.toolStripAddPassword});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(150, 48);
            // 
            // toolStripAddLogin
            // 
            this.toolStripAddLogin.Name = "toolStripAddLogin";
            this.toolStripAddLogin.Size = new System.Drawing.Size(149, 22);
            this.toolStripAddLogin.Text = "Set Login Field";
            // 
            // toolStripAddPassword
            // 
            this.toolStripAddPassword.Name = "toolStripAddPassword";
            this.toolStripAddPassword.Size = new System.Drawing.Size(149, 22);
            this.toolStripAddPassword.Text = "Set Password Field";
            // 
            // IEModule
            // 
            this.Commands.Add(this.cmdPasswordKeeper);
            this.HandleShortcuts = true;
            this.LoadInMainProcess = false;
            this.ModuleName = "PasswordKeeper";
            this.OnConnect += new AddinExpress.IE.ADXIEConnect_EventHandler(this.IEModule_OnConnect);
            this.OnShowContextMenu += new AddinExpress.IE.ADXIEShowContextMenu_EventHandler(this.IEModule_OnShowContextMenu);
            this.contextMenu.ResumeLayout(false);

        }
        #endregion

        #region ADX automatic code

        // Required by Add-in Express - do not modify
        // the methods within this region

        public override System.ComponentModel.IContainer GetContainer()
        {
            if (components == null)
                components = new System.ComponentModel.Container();
            return components;
        }

        [ComRegisterFunctionAttribute]
        public static void RegisterIEModule(Type t)
        {
            AddinExpress.IE.ADXIEModule.RegisterIEModuleInternal(t);
        }

        [ComUnregisterFunctionAttribute]
        public static void UnregisterIEModule(Type t)
        {
            AddinExpress.IE.ADXIEModule.UnregisterIEModuleInternal(t);
        }

        [ComVisible(true)]
        public class IECustomContextMenuCommands :
            AddinExpress.IE.ADXIEModule.ADXIEContextMenuCommandDispatcher
        {
        }

        [ComVisible(true)]
        public class IECustomCommands :
            AddinExpress.IE.ADXIEModule.ADXIECommandDispatcher
        {
        }

        #endregion

        public IE.WebBrowser IEApp
        {
            get
            {
                return (IEObj as IE.WebBrowser);
            }
        }

        public mshtml.HTMLDocument HTMLDocument
        {
            get
            {
                return (HTMLDocumentObj as mshtml.HTMLDocument);
            }
        }

        // Used for context menu
        private mshtml.IHTMLElement TargetElem = null;

        private void IEModule_OnConnect(object sender, int threadId)
        {
            cmdPasswordKeeper.OnClick += CmdPasswordKeeper_OnClick;

            toolStripAddLogin.Click += ToolStripAddLogin_Click;
            toolStripAddPassword.Click += ToolStripAddPassword_Click;
        }

        /// <summary>
        /// Show or hide the left pane
        /// </summary>
        private void CmdPasswordKeeper_OnClick(object sender, object htmlDoc)
        {
            // Show / Hide the left pane
            advBarItemPasswordLeftPane.Visible = !advBarItemPasswordLeftPane.Visible;
        }

        private void IEModule_OnShowContextMenu(object sender, ADXIEShowContextMenuEventArgs e)
        {
            // Only controls
            if (e.ContextMenu != ADXIEShowContextMenuEventArgs.ADXIEDocContextMenu.Control)
                return;
            
            TargetElem = e.HTMLElement as mshtml.IHTMLElement;

            // Only input controls but no buttons
            if (TargetElem.tagName.ToLower().Equals("input") && !TargetElem.getAttribute("type").ToString().ToLower().Equals("submit"))
            {
                e.Handled = true;

                // Disabling menus if no password is selected in the list
                toolStripAddLogin.Enabled = Tools.IdCurrentPassword != null;
                toolStripAddPassword.Enabled = Tools.IdCurrentPassword != null;

                contextMenu.Show(e.Location);
            }
        }

        private void ToolStripAddLogin_Click(object sender, EventArgs e)
        {
            if (TargetElem == null)
                return;

            // Add custom control id for the login field if an entry is selected in the list
            if (Tools.IdCurrentPassword != null)
                new CustomFieldController().AddOrUpdateCustomField(Tools.TypeField.Login, Convert.ToInt32(Tools.IdCurrentPassword), TargetElem.id);
        }

        private void ToolStripAddPassword_Click(object sender, EventArgs e)
        {
            if (TargetElem == null)
                return;

            // Add custom control id for the password field if an entry is selected in the list
            if (Tools.IdCurrentPassword != null)
                new CustomFieldController().AddOrUpdateCustomField(Tools.TypeField.Password, Convert.ToInt32(Tools.IdCurrentPassword), TargetElem.id);
        }
    }
}