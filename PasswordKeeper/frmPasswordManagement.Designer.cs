namespace PasswordKeeper
{
    partial class frmPasswordManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label lblDisplayName;
            System.Windows.Forms.Label lblUserName;
            System.Windows.Forms.Label lblPassword;
            System.Windows.Forms.Label lblNotes;
            System.Windows.Forms.Label lblUrl;
            System.Windows.Forms.Label lblPasswordConfirmation;
            System.Windows.Forms.Label lblPasswordCrackTime;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPasswordManagement));
            System.Windows.Forms.Label lblPasswordEntropy;
            System.Windows.Forms.Label lblPasswordLength;
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnShowPassword = new System.Windows.Forms.Button();
            this.txtPasswordConfirmation = new System.Windows.Forms.TextBox();
            this.grpPasswordProperties = new System.Windows.Forms.GroupBox();
            this.cpbPasswordStrength = new CircularProgressBar.CircularProgressBar();
            this.lblPasswordStrength = new System.Windows.Forms.Label();
            this.lblPasswordCrackTimeValue = new System.Windows.Forms.Label();
            this.lblPasswordEntropyValue = new System.Windows.Forms.Label();
            this.lblPasswordLengthValue = new System.Windows.Forms.Label();
            lblDisplayName = new System.Windows.Forms.Label();
            lblUserName = new System.Windows.Forms.Label();
            lblPassword = new System.Windows.Forms.Label();
            lblNotes = new System.Windows.Forms.Label();
            lblUrl = new System.Windows.Forms.Label();
            lblPasswordConfirmation = new System.Windows.Forms.Label();
            lblPasswordCrackTime = new System.Windows.Forms.Label();
            lblPasswordEntropy = new System.Windows.Forms.Label();
            lblPasswordLength = new System.Windows.Forms.Label();
            this.grpPasswordProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDisplayName
            // 
            lblDisplayName.AutoSize = true;
            lblDisplayName.Location = new System.Drawing.Point(12, 9);
            lblDisplayName.Name = "lblDisplayName";
            lblDisplayName.Size = new System.Drawing.Size(80, 15);
            lblDisplayName.TabIndex = 3;
            lblDisplayName.Text = "Display Name";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new System.Drawing.Point(12, 38);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new System.Drawing.Size(65, 15);
            lblUserName.TabIndex = 4;
            lblUserName.Text = "User Name";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(12, 67);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(57, 15);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password";
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new System.Drawing.Point(12, 154);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new System.Drawing.Size(38, 15);
            lblNotes.TabIndex = 6;
            lblNotes.Text = "Notes";
            // 
            // lblUrl
            // 
            lblUrl.AutoSize = true;
            lblUrl.Location = new System.Drawing.Point(12, 125);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new System.Drawing.Size(28, 15);
            lblUrl.TabIndex = 7;
            lblUrl.Text = "URL";
            // 
            // lblPasswordConfirmation
            // 
            lblPasswordConfirmation.AutoSize = true;
            lblPasswordConfirmation.Location = new System.Drawing.Point(12, 96);
            lblPasswordConfirmation.Name = "lblPasswordConfirmation";
            lblPasswordConfirmation.Size = new System.Drawing.Size(78, 15);
            lblPasswordConfirmation.TabIndex = 15;
            lblPasswordConfirmation.Text = "Confirmation";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(364, 432);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(283, 432);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "button2";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDisplayName.Location = new System.Drawing.Point(98, 6);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(341, 23);
            this.txtDisplayName.TabIndex = 0;
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(98, 151);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(341, 85);
            this.txtNotes.TabIndex = 12;
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(98, 122);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(341, 23);
            this.txtUrl.TabIndex = 10;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(98, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(290, 23);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(98, 35);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(341, 23);
            this.txtUserName.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.CausesValidation = false;
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDelete.Location = new System.Drawing.Point(15, 432);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.Location = new System.Drawing.Point(394, 64);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(45, 23);
            this.btnShowPassword.TabIndex = 6;
            this.btnShowPassword.Text = "●●●";
            this.btnShowPassword.UseVisualStyleBackColor = true;
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
            // 
            // txtPasswordConfirmation
            // 
            this.txtPasswordConfirmation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPasswordConfirmation.Location = new System.Drawing.Point(98, 93);
            this.txtPasswordConfirmation.Name = "txtPasswordConfirmation";
            this.txtPasswordConfirmation.PasswordChar = '●';
            this.txtPasswordConfirmation.Size = new System.Drawing.Size(290, 23);
            this.txtPasswordConfirmation.TabIndex = 8;
            // 
            // lblPasswordCrackTime
            // 
            lblPasswordCrackTime.AutoSize = true;
            lblPasswordCrackTime.Location = new System.Drawing.Point(211, 94);
            lblPasswordCrackTime.Name = "lblPasswordCrackTime";
            lblPasswordCrackTime.Size = new System.Drawing.Size(85, 15);
            lblPasswordCrackTime.TabIndex = 19;
            lblPasswordCrackTime.Text = "Time to crack :";
            // 
            // grpPasswordProperties
            // 
            this.grpPasswordProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPasswordProperties.Controls.Add(this.lblPasswordLengthValue);
            this.grpPasswordProperties.Controls.Add(lblPasswordLength);
            this.grpPasswordProperties.Controls.Add(this.lblPasswordEntropyValue);
            this.grpPasswordProperties.Controls.Add(lblPasswordEntropy);
            this.grpPasswordProperties.Controls.Add(this.lblPasswordCrackTimeValue);
            this.grpPasswordProperties.Controls.Add(this.lblPasswordStrength);
            this.grpPasswordProperties.Controls.Add(this.cpbPasswordStrength);
            this.grpPasswordProperties.Controls.Add(lblPasswordCrackTime);
            this.grpPasswordProperties.Location = new System.Drawing.Point(12, 242);
            this.grpPasswordProperties.Name = "grpPasswordProperties";
            this.grpPasswordProperties.Size = new System.Drawing.Size(427, 184);
            this.grpPasswordProperties.TabIndex = 20;
            this.grpPasswordProperties.TabStop = false;
            this.grpPasswordProperties.Text = "Password Strength";
            // 
            // cpbPasswordStrength
            // 
            this.cpbPasswordStrength.AnimationFunction = ((WinFormAnimation.AnimationFunctions.Function)(resources.GetObject("cpbPasswordStrength.AnimationFunction")));
            this.cpbPasswordStrength.AnimationSpeed = 500;
            this.cpbPasswordStrength.BackColor = System.Drawing.SystemColors.Control;
            this.cpbPasswordStrength.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Bold);
            this.cpbPasswordStrength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cpbPasswordStrength.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cpbPasswordStrength.InnerMargin = 2;
            this.cpbPasswordStrength.InnerWidth = -1;
            this.cpbPasswordStrength.Location = new System.Drawing.Point(15, 19);
            this.cpbPasswordStrength.MarqueeAnimationSpeed = 2000;
            this.cpbPasswordStrength.Maximum = 5;
            this.cpbPasswordStrength.Name = "cpbPasswordStrength";
            this.cpbPasswordStrength.OuterColor = System.Drawing.Color.Gray;
            this.cpbPasswordStrength.OuterMargin = -25;
            this.cpbPasswordStrength.OuterWidth = 26;
            this.cpbPasswordStrength.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cpbPasswordStrength.ProgressWidth = 25;
            this.cpbPasswordStrength.SecondaryFont = new System.Drawing.Font("Segoe UI", 16F);
            this.cpbPasswordStrength.Size = new System.Drawing.Size(159, 159);
            this.cpbPasswordStrength.StartAngle = 270;
            this.cpbPasswordStrength.Step = 1;
            this.cpbPasswordStrength.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpbPasswordStrength.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cpbPasswordStrength.SubscriptText = "";
            this.cpbPasswordStrength.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpbPasswordStrength.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cpbPasswordStrength.SuperscriptText = "";
            this.cpbPasswordStrength.TabIndex = 20;
            this.cpbPasswordStrength.TextMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.cpbPasswordStrength.Value = 1;
            // 
            // lblPasswordStrength
            // 
            this.lblPasswordStrength.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordStrength.Location = new System.Drawing.Point(180, 126);
            this.lblPasswordStrength.Name = "lblPasswordStrength";
            this.lblPasswordStrength.Size = new System.Drawing.Size(241, 43);
            this.lblPasswordStrength.TabIndex = 21;
            this.lblPasswordStrength.Text = "Strength";
            this.lblPasswordStrength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPasswordCrackTimeValue
            // 
            this.lblPasswordCrackTimeValue.AutoSize = true;
            this.lblPasswordCrackTimeValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordCrackTimeValue.Location = new System.Drawing.Point(300, 88);
            this.lblPasswordCrackTimeValue.Name = "lblPasswordCrackTimeValue";
            this.lblPasswordCrackTimeValue.Size = new System.Drawing.Size(53, 21);
            this.lblPasswordCrackTimeValue.TabIndex = 22;
            this.lblPasswordCrackTimeValue.Text = "Value";
            // 
            // lblPasswordEntropyValue
            // 
            this.lblPasswordEntropyValue.AutoSize = true;
            this.lblPasswordEntropyValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordEntropyValue.Location = new System.Drawing.Point(300, 49);
            this.lblPasswordEntropyValue.Name = "lblPasswordEntropyValue";
            this.lblPasswordEntropyValue.Size = new System.Drawing.Size(53, 21);
            this.lblPasswordEntropyValue.TabIndex = 24;
            this.lblPasswordEntropyValue.Text = "Value";
            // 
            // lblPasswordEntropy
            // 
            lblPasswordEntropy.AutoSize = true;
            lblPasswordEntropy.Location = new System.Drawing.Point(211, 55);
            lblPasswordEntropy.Name = "lblPasswordEntropy";
            lblPasswordEntropy.Size = new System.Drawing.Size(54, 15);
            lblPasswordEntropy.TabIndex = 23;
            lblPasswordEntropy.Text = "Entropy :";
            // 
            // lblPasswordLengthValue
            // 
            this.lblPasswordLengthValue.AutoSize = true;
            this.lblPasswordLengthValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordLengthValue.Location = new System.Drawing.Point(300, 13);
            this.lblPasswordLengthValue.Name = "lblPasswordLengthValue";
            this.lblPasswordLengthValue.Size = new System.Drawing.Size(53, 21);
            this.lblPasswordLengthValue.TabIndex = 26;
            this.lblPasswordLengthValue.Text = "Value";
            // 
            // lblPasswordLength
            // 
            lblPasswordLength.AutoSize = true;
            lblPasswordLength.Location = new System.Drawing.Point(211, 19);
            lblPasswordLength.Name = "lblPasswordLength";
            lblPasswordLength.Size = new System.Drawing.Size(50, 15);
            lblPasswordLength.TabIndex = 25;
            lblPasswordLength.Text = "Length :";
            // 
            // frmPasswordManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(451, 467);
            this.ControlBox = false;
            this.Controls.Add(this.grpPasswordProperties);
            this.Controls.Add(this.txtPasswordConfirmation);
            this.Controls.Add(lblPasswordConfirmation);
            this.Controls.Add(this.btnShowPassword);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(lblUrl);
            this.Controls.Add(lblNotes);
            this.Controls.Add(lblPassword);
            this.Controls.Add(lblUserName);
            this.Controls.Add(lblDisplayName);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPasswordManagement";
            this.Text = "frmPasswordManagement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPasswordManagement_FormClosing);
            this.Load += new System.EventHandler(this.frmPasswordManagement_Load);
            this.grpPasswordProperties.ResumeLayout(false);
            this.grpPasswordProperties.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnShowPassword;
        private System.Windows.Forms.TextBox txtPasswordConfirmation;
        private System.Windows.Forms.GroupBox grpPasswordProperties;
        private CircularProgressBar.CircularProgressBar cpbPasswordStrength;
        private System.Windows.Forms.Label lblPasswordStrength;
        private System.Windows.Forms.Label lblPasswordEntropyValue;
        private System.Windows.Forms.Label lblPasswordCrackTimeValue;
        private System.Windows.Forms.Label lblPasswordLengthValue;
    }
}