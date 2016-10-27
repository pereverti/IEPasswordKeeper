using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using IE = Interop.SHDocVw;
using AddinExpress.IE;
using System.Collections.Generic;

namespace PasswordKeeper
{
    /// <summary>
    /// Add-in Express for Internet Explorer Bar
    /// </summary>
    [ComVisible(true), Guid("1C8F1522-72CB-4979-A166-A432F0698384")]
    public class MyIEAdvancedBar1 : ADXIEAdvancedBar
    {
        public MyIEAdvancedBar1()
        {
            InitializeComponent();
        }

        private ListBox lstPasswords;
        private Panel pnlLogin;
        private LinkLabel lnkRegister;
        private TextBox txtDisplayName;
        private Label lblDisplayName;
        private Button btnLoginAction;
        private TextBox txtPassword;
        private TextBox txtLogin;
        private Panel pnlPasswords;
        private Button btnNewPassword;
        private Button btnLogout;
        private Label lblConnectedUserFriendlyName;
        private Label lblConnectedUser;
        private ToolTip toolTipPassword;
        private TextBox txtConfirmPassword;
        private Label lblConfirmPassword;
        private Button btnSettings;
        private Button btnUserUpdateCancel;
        private Button btnDeleteUser;
        private Button btnAutoTypeTop;
        private Button btnAutoTypeBottom;
        private ContextMenuStrip ctxMenuCopy;
        private ToolStripMenuItem toolStripCopyUser;
        private ToolStripMenuItem toolStripCopyPassword;
        private ToolStripMenuItem copyURLToolStripMenuItem;
        private BrightIdeasSoftware.FastDataListView olvPasswords;
        private BrightIdeasSoftware.OLVColumn colDisplayName;
        private BrightIdeasSoftware.OLVColumn colUserName;
        private BrightIdeasSoftware.OLVColumn colPassword;
        private BrightIdeasSoftware.OLVColumn colUrl;

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
            System.Windows.Forms.Label lblListPasswords;
            System.Windows.Forms.Label lblTitle;
            System.Windows.Forms.Label lblLogin;
            System.Windows.Forms.Label lblPassword;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyIEAdvancedBar1));
            this.lblConnectedUserFriendlyName = new System.Windows.Forms.Label();
            this.lblConnectedUser = new System.Windows.Forms.Label();
            this.lstPasswords = new System.Windows.Forms.ListBox();
            this.ctxMenuCopy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripCopyUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCopyPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.copyURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnUserUpdateCancel = new System.Windows.Forms.Button();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lnkRegister = new System.Windows.Forms.LinkLabel();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.btnLoginAction = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.pnlPasswords = new System.Windows.Forms.Panel();
            this.btnAutoTypeBottom = new System.Windows.Forms.Button();
            this.btnAutoTypeTop = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnNewPassword = new System.Windows.Forms.Button();
            this.toolTipPassword = new System.Windows.Forms.ToolTip(this.components);
            this.olvPasswords = new BrightIdeasSoftware.FastDataListView();
            this.colDisplayName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colUserName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colPassword = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colUrl = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            lblListPasswords = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            lblLogin = new System.Windows.Forms.Label();
            lblPassword = new System.Windows.Forms.Label();
            this.ctxMenuCopy.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.pnlPasswords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvPasswords)).BeginInit();
            this.SuspendLayout();
            // 
            // lblListPasswords
            // 
            lblListPasswords.AutoSize = true;
            lblListPasswords.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblListPasswords.Location = new System.Drawing.Point(4, 79);
            lblListPasswords.Name = "lblListPasswords";
            lblListPasswords.Size = new System.Drawing.Size(83, 15);
            lblListPasswords.TabIndex = 14;
            lblListPasswords.Text = "Passwords List";
            // 
            // lblTitle
            // 
            lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTitle.Location = new System.Drawing.Point(35, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(218, 37);
            lblTitle.TabIndex = 17;
            lblTitle.Text = "Password Keeper";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new System.Drawing.Point(3, 10);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new System.Drawing.Size(36, 15);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Email";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(3, 39);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(57, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";
            // 
            // lblConnectedUserFriendlyName
            // 
            this.lblConnectedUserFriendlyName.AutoSize = true;
            this.lblConnectedUserFriendlyName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectedUserFriendlyName.Location = new System.Drawing.Point(3, 15);
            this.lblConnectedUserFriendlyName.Name = "lblConnectedUserFriendlyName";
            this.lblConnectedUserFriendlyName.Size = new System.Drawing.Size(148, 21);
            this.lblConnectedUserFriendlyName.TabIndex = 15;
            this.lblConnectedUserFriendlyName.Text = "User Friendly Name";
            // 
            // lblConnectedUser
            // 
            this.lblConnectedUser.AutoSize = true;
            this.lblConnectedUser.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectedUser.Location = new System.Drawing.Point(4, 36);
            this.lblConnectedUser.Name = "lblConnectedUser";
            this.lblConnectedUser.Size = new System.Drawing.Size(55, 12);
            this.lblConnectedUser.TabIndex = 16;
            this.lblConnectedUser.Text = "User Name";
            // 
            // lstPasswords
            // 
            this.lstPasswords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPasswords.ContextMenuStrip = this.ctxMenuCopy;
            this.lstPasswords.FormattingEnabled = true;
            this.lstPasswords.Location = new System.Drawing.Point(4, 97);
            this.lstPasswords.Name = "lstPasswords";
            this.lstPasswords.Size = new System.Drawing.Size(296, 173);
            this.lstPasswords.TabIndex = 22;
            this.lstPasswords.DoubleClick += new System.EventHandler(this.lstPasswords_DoubleClick);
            this.lstPasswords.MouseHover += new System.EventHandler(this.lstPasswords_MouseHover);
            // 
            // ctxMenuCopy
            // 
            this.ctxMenuCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCopyUser,
            this.toolStripCopyPassword,
            this.copyURLToolStripMenuItem});
            this.ctxMenuCopy.Name = "ctxMenuCopy";
            this.ctxMenuCopy.Size = new System.Drawing.Size(156, 70);
            this.ctxMenuCopy.Text = "Clipboard Copy";
            // 
            // toolStripCopyUser
            // 
            this.toolStripCopyUser.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCopyUser.Image")));
            this.toolStripCopyUser.Name = "toolStripCopyUser";
            this.toolStripCopyUser.Size = new System.Drawing.Size(155, 22);
            this.toolStripCopyUser.Text = "Copy User";
            this.toolStripCopyUser.Click += new System.EventHandler(this.toolStripCopyUser_Click);
            // 
            // toolStripCopyPassword
            // 
            this.toolStripCopyPassword.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCopyPassword.Image")));
            this.toolStripCopyPassword.Name = "toolStripCopyPassword";
            this.toolStripCopyPassword.Size = new System.Drawing.Size(155, 22);
            this.toolStripCopyPassword.Text = "Copy Password";
            this.toolStripCopyPassword.Click += new System.EventHandler(this.toolStripCopyPassword_Click);
            // 
            // copyURLToolStripMenuItem
            // 
            this.copyURLToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyURLToolStripMenuItem.Image")));
            this.copyURLToolStripMenuItem.Name = "copyURLToolStripMenuItem";
            this.copyURLToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.copyURLToolStripMenuItem.Text = "Copy URL";
            this.copyURLToolStripMenuItem.Click += new System.EventHandler(this.copyURLToolStripMenuItem_Click);
            // 
            // pnlLogin
            // 
            this.pnlLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLogin.Controls.Add(this.btnDeleteUser);
            this.pnlLogin.Controls.Add(this.btnUserUpdateCancel);
            this.pnlLogin.Controls.Add(this.txtConfirmPassword);
            this.pnlLogin.Controls.Add(this.lblConfirmPassword);
            this.pnlLogin.Controls.Add(this.lnkRegister);
            this.pnlLogin.Controls.Add(this.txtDisplayName);
            this.pnlLogin.Controls.Add(this.lblDisplayName);
            this.pnlLogin.Controls.Add(this.btnLoginAction);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(lblPassword);
            this.pnlLogin.Controls.Add(this.txtLogin);
            this.pnlLogin.Controls.Add(lblLogin);
            this.pnlLogin.Location = new System.Drawing.Point(0, 40);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(303, 191);
            this.pnlLogin.TabIndex = 16;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteUser.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.Location = new System.Drawing.Point(4, 160);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteUser.TabIndex = 13;
            this.btnDeleteUser.Text = "Delete";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Visible = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnUserUpdateCancel
            // 
            this.btnUserUpdateCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserUpdateCancel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserUpdateCancel.Location = new System.Drawing.Point(128, 160);
            this.btnUserUpdateCancel.Name = "btnUserUpdateCancel";
            this.btnUserUpdateCancel.Size = new System.Drawing.Size(75, 23);
            this.btnUserUpdateCancel.TabIndex = 12;
            this.btnUserUpdateCancel.Text = "Cancel";
            this.btnUserUpdateCancel.UseVisualStyleBackColor = true;
            this.btnUserUpdateCancel.Visible = false;
            this.btnUserUpdateCancel.Click += new System.EventHandler(this.btnUserUpdateCancel_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(113, 65);
            this.txtConfirmPassword.MaxLength = 255;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.Size = new System.Drawing.Size(171, 23);
            this.txtConfirmPassword.TabIndex = 5;
            this.txtConfirmPassword.Visible = false;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(3, 68);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(104, 15);
            this.lblConfirmPassword.TabIndex = 11;
            this.lblConfirmPassword.Text = "Confirm Password";
            this.lblConfirmPassword.Visible = false;
            // 
            // lnkRegister
            // 
            this.lnkRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkRegister.AutoSize = true;
            this.lnkRegister.Location = new System.Drawing.Point(3, 165);
            this.lnkRegister.Name = "lnkRegister";
            this.lnkRegister.Size = new System.Drawing.Size(49, 15);
            this.lnkRegister.TabIndex = 11;
            this.lnkRegister.TabStop = true;
            this.lnkRegister.Text = "Register";
            this.lnkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegister_LinkClicked);
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDisplayName.Location = new System.Drawing.Point(113, 94);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(171, 23);
            this.txtDisplayName.TabIndex = 7;
            this.txtDisplayName.Visible = false;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Location = new System.Drawing.Point(3, 97);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(80, 15);
            this.lblDisplayName.TabIndex = 10;
            this.lblDisplayName.Text = "Display Name";
            this.lblDisplayName.Visible = false;
            // 
            // btnLoginAction
            // 
            this.btnLoginAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoginAction.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginAction.Location = new System.Drawing.Point(209, 160);
            this.btnLoginAction.Name = "btnLoginAction";
            this.btnLoginAction.Size = new System.Drawing.Size(75, 23);
            this.btnLoginAction.TabIndex = 9;
            this.btnLoginAction.Text = "Connect";
            this.btnLoginAction.UseVisualStyleBackColor = true;
            this.btnLoginAction.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(113, 36);
            this.txtPassword.MaxLength = 255;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(171, 23);
            this.txtPassword.TabIndex = 3;
            // 
            // txtLogin
            // 
            this.txtLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogin.Location = new System.Drawing.Point(113, 7);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(171, 23);
            this.txtLogin.TabIndex = 1;
            // 
            // pnlPasswords
            // 
            this.pnlPasswords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPasswords.Controls.Add(this.olvPasswords);
            this.pnlPasswords.Controls.Add(this.btnAutoTypeBottom);
            this.pnlPasswords.Controls.Add(this.btnAutoTypeTop);
            this.pnlPasswords.Controls.Add(this.btnSettings);
            this.pnlPasswords.Controls.Add(this.lstPasswords);
            this.pnlPasswords.Controls.Add(this.btnLogout);
            this.pnlPasswords.Controls.Add(this.btnNewPassword);
            this.pnlPasswords.Controls.Add(this.lblConnectedUser);
            this.pnlPasswords.Controls.Add(this.lblConnectedUserFriendlyName);
            this.pnlPasswords.Controls.Add(lblListPasswords);
            this.pnlPasswords.Location = new System.Drawing.Point(0, 40);
            this.pnlPasswords.Name = "pnlPasswords";
            this.pnlPasswords.Size = new System.Drawing.Size(303, 617);
            this.pnlPasswords.TabIndex = 18;
            this.pnlPasswords.Visible = false;
            // 
            // btnAutoTypeBottom
            // 
            this.btnAutoTypeBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoTypeBottom.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoTypeBottom.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoTypeBottom.Image")));
            this.btnAutoTypeBottom.Location = new System.Drawing.Point(277, 591);
            this.btnAutoTypeBottom.Name = "btnAutoTypeBottom";
            this.btnAutoTypeBottom.Size = new System.Drawing.Size(23, 23);
            this.btnAutoTypeBottom.TabIndex = 27;
            this.btnAutoTypeBottom.UseVisualStyleBackColor = true;
            this.btnAutoTypeBottom.Click += new System.EventHandler(this.btnAutoType_Click);
            // 
            // btnAutoTypeTop
            // 
            this.btnAutoTypeTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoTypeTop.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoTypeTop.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoTypeTop.Image")));
            this.btnAutoTypeTop.Location = new System.Drawing.Point(277, 71);
            this.btnAutoTypeTop.Name = "btnAutoTypeTop";
            this.btnAutoTypeTop.Size = new System.Drawing.Size(23, 23);
            this.btnAutoTypeTop.TabIndex = 26;
            this.btnAutoTypeTop.UseVisualStyleBackColor = true;
            this.btnAutoTypeTop.Click += new System.EventHandler(this.btnAutoType_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.Location = new System.Drawing.Point(196, 13);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(23, 23);
            this.btnSettings.TabIndex = 25;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(225, 13);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 20;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnNewPassword
            // 
            this.btnNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewPassword.Location = new System.Drawing.Point(4, 591);
            this.btnNewPassword.Name = "btnNewPassword";
            this.btnNewPassword.Size = new System.Drawing.Size(75, 23);
            this.btnNewPassword.TabIndex = 24;
            this.btnNewPassword.Text = "New";
            this.btnNewPassword.UseVisualStyleBackColor = true;
            this.btnNewPassword.Click += new System.EventHandler(this.btnNewPassword_Click);
            // 
            // toolTipPassword
            // 
            this.toolTipPassword.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // olvPasswords
            // 
            this.olvPasswords.AllColumns.Add(this.colDisplayName);
            this.olvPasswords.AllColumns.Add(this.colUserName);
            this.olvPasswords.AllColumns.Add(this.colPassword);
            this.olvPasswords.AllColumns.Add(this.colUrl);
            this.olvPasswords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvPasswords.CellEditUseWholeCell = false;
            this.olvPasswords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDisplayName,
            this.colUserName,
            this.colPassword,
            this.colUrl});
            this.olvPasswords.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvPasswords.DataSource = null;
            this.olvPasswords.FullRowSelect = true;
            this.olvPasswords.GridLines = true;
            this.olvPasswords.Location = new System.Drawing.Point(4, 276);
            this.olvPasswords.MultiSelect = false;
            this.olvPasswords.Name = "olvPasswords";
            this.olvPasswords.SelectAllOnControlA = false;
            this.olvPasswords.ShowGroups = false;
            this.olvPasswords.Size = new System.Drawing.Size(296, 285);
            this.olvPasswords.TabIndex = 28;
            this.olvPasswords.UseAlternatingBackColors = true;
            this.olvPasswords.UseCompatibleStateImageBehavior = false;
            this.olvPasswords.View = System.Windows.Forms.View.Details;
            this.olvPasswords.VirtualMode = true;
            this.olvPasswords.DoubleClick += new System.EventHandler(this.olvPasswords_DoubleClick);
            // 
            // colDisplayName
            // 
            this.colDisplayName.AspectName = "DisplayName";
            this.colDisplayName.Text = "Title";
            this.colDisplayName.Width = 100;
            // 
            // colUserName
            // 
            this.colUserName.AspectName = "Login";
            this.colUserName.Text = "User Name";
            // 
            // colPassword
            // 
            this.colPassword.AspectName = "";
            this.colPassword.AspectToStringFormat = "";
            this.colPassword.Sortable = false;
            this.colPassword.Text = "Password";
            // 
            // colUrl
            // 
            this.colUrl.AspectName = "Url";
            this.colUrl.Text = "Url";
            // 
            // MyIEAdvancedBar1
            // 
            this.Controls.Add(lblTitle);
            this.Controls.Add(this.pnlPasswords);
            this.Controls.Add(this.pnlLogin);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MyIEAdvancedBar1";
            this.Size = new System.Drawing.Size(303, 660);
            this.ctxMenuCopy.ResumeLayout(false);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlPasswords.ResumeLayout(false);
            this.pnlPasswords.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvPasswords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        #endregion

        public IE.WebBrowser IEApp
        {
            get
            {
                return (Module.IEObj as IE.WebBrowser);
            }
        }

        public mshtml.HTMLDocument HTMLDocument
        {
            get
            {
                return (Module.HTMLDocumentObj as mshtml.HTMLDocument);
            }
        }

        public string OptionLogin
        {
            get { return txtLogin.Text; }
            set { txtLogin.Text = value; }
        }

        public string OptionPassword
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }

        private UserModel CurrentUser;

        private enum TypeLogin
        {
            Connect,
            Register,
            Update
        }

        private enum TypePanel
        {
            Login,
            Passwords
        }

        #region Events

        /// <summary>
        /// Click on the register link
        /// </summary>
        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lnkRegister.Text.Equals(Tools.LblLinkButtonRegister))
                ToggleLoginPanelControls(TypeLogin.Register);
            else if (lnkRegister.Text.Equals(Tools.LblLinkButtonCancel))
                ToggleLoginPanelControls(TypeLogin.Connect);
        }

        /// <summary>
        /// CLick event of the button connection
        /// </summary>
        /// <remarks>This button is also used to save a new user (registration mode)</remarks>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            switch (btnLoginAction.Text)
            {
                case Tools.lblButtonConnect:
                    if (CheckCredentials())
                    {
                        InitPanelPasswords();
                        LoadPasswordsList();

                        TogglePanelsLoginPasswords(TypePanel.Passwords);
                    }

                    break;
                case Tools.LblButtonRegister:
                    // Back to connection mode if registration succeeds
                    if (RegisterNewUser())
                        ToggleLoginPanelControls(TypeLogin.Connect);

                    break;
                case Tools.lblButtonUpdate:
                    if (UpdateUser())
                    {
                        TogglePanelsLoginPasswords(TypePanel.Passwords);
                        InitPanelPasswords();
                    }

                    break;
            }
        }

        /// <summary>
        /// Create a new password entry
        /// </summary>
        private void btnNewPassword_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Cancel;

            using (frmPasswordManagement newPassword = new frmPasswordManagement(Tools.PasswordAction.Create, CurrentUser.Id))
            {
                result = newPassword.ShowDialog();
            }

            if (result == DialogResult.OK)
                LoadPasswordsList();
        }

        /// <summary>
        /// Quit current session
        /// </summary>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Clean();

            TogglePanelsLoginPasswords(TypePanel.Login);
            ToggleLoginPanelControls(TypeLogin.Connect);
        }

        /// <summary>
        /// Edit selected entry
        /// </summary>
        private void lstPasswords_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Cancel;

            using (frmPasswordManagement updatedPassword = new frmPasswordManagement(Tools.PasswordAction.Edit, CurrentUser.Id, (PasswordModel)lstPasswords.SelectedItem))
            {
                result = updatedPassword.ShowDialog();
            }

            if (result == DialogResult.OK)
                LoadPasswordsList();
        }

        /// <summary>
        /// Edit current user
        /// </summary>
        private void btnSettings_Click(object sender, EventArgs e)
        {
            TogglePanelsLoginPasswords(TypePanel.Login);
            ToggleLoginPanelControls(TypeLogin.Update);

            FillUserControls();
        }

        /// <summary>
        /// Cancel user update
        /// </summary>
        private void btnUserUpdateCancel_Click(object sender, EventArgs e)
        {
            TogglePanelsLoginPasswords(TypePanel.Passwords);
        }

        /// <summary>
        /// Delete current user
        /// </summary>
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Concat("Are you sure you want to delete the user \"", CurrentUser.DisplayName, "\""), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                new UserController().Delete(CurrentUser.Id);

                Clean();

                TogglePanelsLoginPasswords(TypePanel.Login);
                ToggleLoginPanelControls(TypeLogin.Connect);
            }
        }

        /// <summary>
        /// Copy selected entry login in the clipboard
        /// </summary>
        private void toolStripCopyUser_Click(object sender, EventArgs e)
        {
            if (lstPasswords.SelectedItem == null)
                return;

            Clipboard.SetText(((PasswordModel)lstPasswords.SelectedItem).Login);
        }

        /// <summary>
        /// Copy selected entry password in the clipboard
        /// </summary>
        private void toolStripCopyPassword_Click(object sender, EventArgs e)
        {
            if (lstPasswords.SelectedItem == null)
                return;

            Clipboard.SetText(((PasswordModel)lstPasswords.SelectedItem).Password);
        }

        /// <summary>
        /// Copy selected entry url in the clipboard
        /// </summary>
        private void copyURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstPasswords.SelectedItem == null)
                return;

            Clipboard.SetText(((PasswordModel)lstPasswords.SelectedItem).Url);
        }

        /// <summary>
        /// Click on auto-type buttons
        /// </summary>
        private void btnAutoType_Click(object sender, EventArgs e)
        {
            mshtml.IHTMLElement elem = HTMLDocument.getElementById("Name");
            if (elem is mshtml.HTMLInputElement)
            {
                mshtml.HTMLInputElement input = elem as mshtml.HTMLInputElement;
                input.disabled = true;
                input.click();
            }


            if (lstPasswords.SelectedItem == null)
                return;

            PasswordModel currentPassword = ((PasswordModel)lstPasswords.SelectedItem);

            mshtml.IHTMLElementCollection inputCollection = HTMLDocument.getElementsByTagName("input");

            foreach (mshtml.IHTMLElement element in inputCollection)
            {
                if (element.id != null)
                {
                    if (element.id.ToLower().Contains("login"))
                    {
                        element.setAttribute("value", currentPassword.Login);
                    }
                    else if (element.id.ToLower().Contains("pass"))
                    {
                        element.setAttribute("value", currentPassword.Password);
                    }
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Clean controls and objects
        /// </summary>
        private void Clean()
        {
            CurrentUser = null;

            txtLogin.Text = string.Empty;
            txtDisplayName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
        }

        /// <summary>
        /// Fill user texbox with user values
        /// </summary>
        private void FillUserControls()
        {
            txtLogin.Text = CurrentUser.Login;
            txtDisplayName.Text = CurrentUser.DisplayName;
            txtPassword.Text = CurrentUser.Password;
            txtConfirmPassword.Text = CurrentUser.Password;
        }

        /// <summary>
        /// Initialize panel controls
        /// </summary>
        private void InitPanelPasswords()
        {
            lblConnectedUser.Text = CurrentUser.Login;
            lblConnectedUserFriendlyName.Text = CurrentUser.DisplayName;
        }

        private void LoadPasswordsList()
        {
            lstPasswords.DataSource = new PasswordController().GetList(CurrentUser.Id);
            lstPasswords.DisplayMember = "DisplayName";

            // Fast ListView
            //olvPasswords.DataSource = new PasswordController().GetList(CurrentUser.Id);
            olvPasswords.SetObjects(new PasswordController().GetList(CurrentUser.Id));
        }

        /// <summary>
        /// Manage the behaviour of the connection panel
        /// </summary>
        /// <param name="mode">Connection mode (registration or connection)</param>
        private void ToggleLoginPanelControls(TypeLogin mode)
        {
            switch (mode)
            {
                case TypeLogin.Register:
                    lblDisplayName.Visible = true;
                    lblConfirmPassword.Visible = true;

                    txtLogin.Enabled = true;
                    txtDisplayName.Visible = true;
                    txtConfirmPassword.Visible = true;

                    btnLoginAction.Text = Tools.LblButtonRegister;
                    btnUserUpdateCancel.Visible = false;
                    btnDeleteUser.Visible = false;

                    lnkRegister.Visible = true;
                    lnkRegister.Text = Tools.LblLinkButtonCancel;

                    break;
                case TypeLogin.Connect:
                    lblDisplayName.Visible = false;
                    lblConfirmPassword.Visible = false;

                    txtLogin.Enabled = true;
                    txtDisplayName.Visible = false;
                    txtConfirmPassword.Visible = false;

                    btnLoginAction.Text = Tools.lblButtonConnect;
                    btnUserUpdateCancel.Visible = false;
                    btnDeleteUser.Visible = false;

                    lnkRegister.Visible = true;
                    lnkRegister.Text = Tools.LblLinkButtonRegister;

                    break;
                case TypeLogin.Update:
                    lblDisplayName.Visible = true;
                    lblConfirmPassword.Visible = true;

                    txtLogin.Enabled = false;
                    txtDisplayName.Visible = true;
                    txtConfirmPassword.Visible = true;

                    btnLoginAction.Text = Tools.lblButtonUpdate;
                    btnUserUpdateCancel.Visible = true;
                    btnDeleteUser.Visible = true;

                    lnkRegister.Visible = false;

                    break;
            }
        }

        /// <summary>
        /// Management of the different panels
        /// </summary>
        /// <param name="kindOfPanel">Type of panel shown</param>
        private void TogglePanelsLoginPasswords(TypePanel kindOfPanel)
        {
            switch (kindOfPanel)
            {
                case TypePanel.Login:
                    pnlLogin.Visible = true;
                    pnlPasswords.Visible = false;

                    break;
                case TypePanel.Passwords:
                    pnlLogin.Visible = false;
                    pnlPasswords.Visible = true;

                    break;
            }
        }

        /// <summary>
        /// Check the credentials and get the user connected
        /// </summary>
        /// <returns>true if the credentials are ok, false otherwise</returns>
        private bool CheckCredentials()
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("All fields are required !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            UserController controlUser = new UserController();

            CurrentUser = controlUser.GetUser(txtLogin.Text.Trim(), txtPassword.Text.Trim());

            if (CurrentUser == null)
            {
                MessageBox.Show("User not found or incorrect credentials !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        /// <summary>
        /// Chack if the user fields are filled
        /// </summary>
        /// <returns>true if all fields are filled, false otherwise</returns>
        private bool CheckUserFieldsEmpty()
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmPassword.Text) || string.IsNullOrWhiteSpace(txtDisplayName.Text))
            {
                MessageBox.Show("All fields are required !", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }

            return true;
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <returns>true if the registration is done correctly, false otherwise</returns>
        private bool RegisterNewUser()
        {
            // Control all fields are correctly filled
            if (!CheckUserFieldsEmpty())
                return false;

            // Check email format
            if (!Tools.IsValidEmail(txtLogin.Text.Trim()))
            {
                MessageBox.Show("Email is not valid !", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }

            CurrentUser = new UserModel()
            {
                Login = txtLogin.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                DisplayName = txtDisplayName.Text.Trim(),
                IsActive = true,
                CreationDate = DateTime.Now
            };

            new UserController().Create(CurrentUser);

            MessageBox.Show(string.Concat(CurrentUser.DisplayName, " sucessfully created."), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }


        /// <summary>
        /// Update current user
        /// </summary>
        /// <returns>true if the update is done correctly, false otherwise</returns>
        private bool UpdateUser()
        {
            // Control all fields are correctly filled
            if (!CheckUserFieldsEmpty())
                return false;

            CurrentUser.Password = txtPassword.Text.Trim();
            CurrentUser.DisplayName = txtDisplayName.Text.Trim();

            new UserController().Update(CurrentUser);

            MessageBox.Show(string.Concat(CurrentUser.DisplayName, " sucessfully updated."), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }

        #endregion

        private void lstPasswords_MouseHover(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedItem == null)
                return;

            PasswordModel hoveredPassword = (PasswordModel)((ListBox)sender).SelectedItem;

            toolTipPassword.Show(hoveredPassword.Url, lstPasswords);
        }

        private void olvPasswords_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}