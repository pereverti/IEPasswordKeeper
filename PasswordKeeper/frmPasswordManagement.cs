using System;
using System.Windows.Forms;

namespace PasswordKeeper
{
    public partial class frmPasswordManagement : Form
    {
        private readonly Tools.PasswordAction Mode;
        private readonly int UserId;
        private readonly string PasswordKey;

        private Zxcvbn.Zxcvbn PasswordEvaluatorEngine;

        private PasswordModel Passwd { get; set; }

        public frmPasswordManagement(Tools.PasswordAction typeOfAction, int usrId, string key)
        {
            InitializeComponent();

            PasswordEvaluatorEngine = new Zxcvbn.Zxcvbn();

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
            if (CheckValidations())
            {
                SavePassword();

                Close();
            }
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

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = txtPassword.PasswordChar.Equals('\0') ? '●' : '\0';
            txtPasswordConfirmation.PasswordChar = txtPassword.PasswordChar;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize controls text and visibility
        /// </summary>
        private void InitControls()
        {
            lblPasswordStrength.Text = string.Empty;

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
        /// Perform password validations
        /// </summary>
        /// <returns>true if valdations are ok, false otherwise</returns>
        private bool CheckValidations()
        {
            if (!txtPassword.Text.Equals(txtPasswordConfirmation.Text))
            {
                MessageBox.Show("Passwords are different !", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }

            return true;
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
            txtPasswordConfirmation.Text = Passwd.Password;
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

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            Zxcvbn.Result passwordResult = PasswordEvaluatorEngine.EvaluatePassword(txtPassword.Text);

            lblPasswordStrength.Text = string.Concat("Crack Time : ", passwordResult.CrackTimeDisplay, "\nEntropy : ", passwordResult.Entropy, " bits\nScore : ", passwordResult.Score);
        }
    }
}