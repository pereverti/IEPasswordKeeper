using System;
using System.Windows.Forms;

namespace PasswordKeeper
{
    public partial class frmPasswordManagement : Form
    {
        private readonly Tools.PasswordAction Mode;
        private readonly int UserId;
        private readonly string PasswordKey;

        private PasswordModel Passwd { get; set; }

        public frmPasswordManagement(Tools.PasswordAction typeOfAction, int usrId, string key)
        {
            InitializeComponent();

            Mode = typeOfAction;
            UserId = usrId;
            PasswordKey = key;
        }

        public frmPasswordManagement(Tools.PasswordAction typeOfAction, int usrId, string key, PasswordModel password) : this(typeOfAction, usrId, key)
        {
            Passwd = password;
        }

        #region Events

        private void frmPasswordManagement_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SavePassword();

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Concat("Are you sure you want to delete the password \"", Passwd.DisplayName, "\""), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                new PasswordController().Delete(Passwd.Id);

                Close();
            }
            else
            {
                frmPasswordManagement_FormClosing(this, new FormClosingEventArgs(CloseReason.None, true));
            }
        }
        private void frmPasswordManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.None)
                e.Cancel = true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize controls text and visibility
        /// </summary>
        private void InitControls()
        {
            switch (Mode)
            {
                case Tools.PasswordAction.Create:
                    Text = "Create new password";
                    btnOk.Text = "Create";
                    btnDelete.Visible = false;

                    break;
                case Tools.PasswordAction.Edit:
                    Text = string.Concat("Edit \"", Passwd.DisplayName, "\" entry");
                    btnOk.Text = "Update";

                    MapObjectToFields();

                    break;
            }
        }

        /// <summary>
        /// Save or update a password
        /// </summary>
        private void SavePassword()
        {
            PasswordController passControler = new PasswordController(PasswordKey);

            MapFieldsToObject();

            switch (Mode)
            {
                case Tools.PasswordAction.Create:
                    passControler.Create(Passwd);

                    break;
                case Tools.PasswordAction.Edit:
                    passControler.Update(Passwd);

                    break;
            }
        }

        /// <summary>
        /// Map object values into controls fields
        /// </summary>
        private void MapObjectToFields()
        {
            txtDisplayName.Text = Passwd.DisplayName;
            txtUserName.Text = Passwd.Login;
            txtPassword.Text = Passwd.Password;
            txtUrl.Text = Passwd.Url;
            txtNotes.Text = Passwd.Notes;
        }

        /// <summary>
        /// Map controls fields into password object
        /// </summary>
        private void MapFieldsToObject()
        {
            if (Passwd == null)
            {
                Passwd = new PasswordModel()
                {
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    UserId = UserId,
                    Key = PasswordKey
                };
            }

            Passwd.DisplayName = txtDisplayName.Text.Trim();
            Passwd.Login = txtUserName.Text.Trim();
            Passwd.Password = txtPassword.Text;
            Passwd.Url = txtUrl.Text.Trim();
            Passwd.Notes = txtNotes.Text.Trim();
        }

        #endregion

    }
}
