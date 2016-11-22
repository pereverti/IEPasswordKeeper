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
        private ADXIECommandItem cmdItemShowHide;
        private ADXIEHTMLDocEvents adxiehtmlDocEvents1;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem toolStripAddLogin;
        private ToolStripMenuItem toolStripAddPassword;
        private ADXIECommandItem cmdItemFillFields;

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
            this.cmdItemFillFields = new AddinExpress.IE.ADXIECommandItem(this.components);
            this.cmdItemShowHide = new AddinExpress.IE.ADXIECommandItem(this.components);
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
            // cmdItemFillFields
            // 
            this.cmdItemFillFields.Caption = "Fill Fields";
            this.cmdItemFillFields.CommandGuid = "{69E4B3E2-8DAD-4FA6-9E1A-20A8A1410070}";
            // 
            // cmdItemShowHide
            // 
            this.cmdItemShowHide.ActiveIcon = "Icons.SampleIcon2";
            this.cmdItemShowHide.Caption = "Show / Hide";
            this.cmdItemShowHide.CommandGuid = "{75235D32-8F17-4E67-9964-2890A4D6A04E}";
            // 
            // adxiehtmlDocEvents1
            // 
            this.adxiehtmlDocEvents1.OnClick += new AddinExpress.IE.ADXIEHTMLEventObjectEx_EventHandler(this.adxiehtmlDocEvents1_OnClick);
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
            this.toolStripAddLogin.Text = "Add Login";
            toolStripAddLogin.Click += ToolStripAddLogin_Click;
            // 
            // toolStripAddPassword
            // 
            this.toolStripAddPassword.Name = "toolStripAddPassword";
            this.toolStripAddPassword.Size = new System.Drawing.Size(149, 22);
            this.toolStripAddPassword.Text = "Add Password";
            // 
            // IEModule
            // 
            this.Commands.Add(this.cmdItemFillFields);
            this.Commands.Add(this.cmdItemShowHide);
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

        // Context menu
        private IOleCommandTarget targetObj = null;
        private mshtml.IHTMLElement targetElem = null;

        public string MasterLogin { get; set; }
        public string MasterPassword { get; set; }

        private void IEModule_OnConnect(object sender, int threadId)
        {
            cmdItemFillFields.OnClick += cmdItemFillFields_OnClick;
            cmdItemShowHide.OnClick += CmdItemShowHide_OnClick;

            // :radioactive: Test for shared data
            SendMessageToAll(Tools.WM_UPDATE_OPTIONS, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// Show or hide the left pane
        /// </summary>
        private void CmdItemShowHide_OnClick(object sender, object htmlDoc)
        {
            // Show / Hide the left pane
            advBarItemPasswordLeftPane.Visible = !advBarItemPasswordLeftPane.Visible;
        }

        // :radioactive: TEST
        void cmdItemFillFields_OnClick(object sender, object htmlDoc)
        {
            mshtml.IHTMLElementCollection inputCollection =
                (mshtml.IHTMLElementCollection)HTMLDocument.getElementsByTagName("input");
            foreach (mshtml.IHTMLElement element in inputCollection)
            {
                if (element.id != null)
                {
                    if (element.id.ToLower().Contains("name"))
                    {
                        if (element.id.ToLower().Contains("first"))
                            element.setAttribute("value", Properties.Settings.Default.FirstName);
                        else
                            element.setAttribute("value", Properties.Settings.Default.LastName);
                    }
                    else if (element.id.ToLower().Contains("mail"))
                    {
                        element.setAttribute("value", Properties.Settings.Default.Email);
                    }
                    else if (element.id.ToLower().Contains("phone"))
                    {
                        element.setAttribute("value", Properties.Settings.Default.Phone);
                    }
                }
            }
        }

        private void adxiehtmlDocEvents1_OnClick(object sender, object eventObject, ADXCancelEventArgs e)
        {

        }

        private void IEModule_OnShowContextMenu(object sender, ADXIEShowContextMenuEventArgs e)
        {
            // Only controls
            if (e.ContextMenu != ADXIEShowContextMenuEventArgs.ADXIEDocContextMenu.Control)
                return;

            targetObj = e.Container as IOleCommandTarget;
            targetElem = e.HTMLElement as mshtml.IHTMLElement;

            // Only input controls but no buttons
            if (targetElem.tagName.ToLower().Equals("input") && !targetElem.getAttribute("type").ToString().ToLower().Equals("submit"))
            {
                e.Handled = true;

                contextMenu.Show(e.Location);
            }
        }

        private void ToolStripAddLogin_Click(object sender, EventArgs e)
        {
            if (targetElem != null)
                MessageBox.Show(this, string.Concat("Id du contrôle de saisie du login : ", targetElem.id), ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            object toto = Tools.CurrentModule.olvPasswords.FocusedObject;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        internal struct OLECMD
        {
            public uint cmdID;
            public uint cmdf;
        }

        [ComImport, Guid("B722BCCB-4E68-101B-A2BC-00AA00404770"), InterfaceType(1)]
        internal interface IOleCommandTarget
        {
            [PreserveSig]
            int QueryStatus(IntPtr pguidCmdGroup, [In] uint cCmds, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] OLECMD[] prgCmds, [In, Out] IntPtr pCmdText);

            [PreserveSig]
            int Exec(IntPtr pCmdGroup, [In] uint nCmdID, [In] uint nCmdexecopt, [In] IntPtr pvaIn, [In] IntPtr pvaOut);
        }
    }
}

