using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POO_25453_TP
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelUsername = new Label();
            labelPassword = new Label();
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            radioButtonClient = new RadioButton();
            radioButtonAccount = new RadioButton();
            buttonLogin = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(70, 30);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(60, 15);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "Username";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(70, 90);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(57, 15);
            labelPassword.TabIndex = 1;
            labelPassword.Text = "Password";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(70, 50);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(232, 23);
            textBoxUsername.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(70, 110);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(232, 23);
            textBoxPassword.TabIndex = 3;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // radioButtonClient
            // 
            radioButtonClient.AutoSize = true;
            radioButtonClient.Checked = true;
            radioButtonClient.Location = new Point(70, 160);
            radioButtonClient.Name = "radioButtonClient";
            radioButtonClient.Size = new Size(56, 19);
            radioButtonClient.TabIndex = 4;
            radioButtonClient.TabStop = true;
            radioButtonClient.Text = "Client";
            radioButtonClient.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccount
            // 
            radioButtonAccount.AutoSize = true;
            radioButtonAccount.Location = new Point(150, 160);
            radioButtonAccount.Name = "radioButtonAccount";
            radioButtonAccount.Size = new Size(70, 19);
            radioButtonAccount.TabIndex = 5;
            radioButtonAccount.Text = "Account";
            radioButtonAccount.UseVisualStyleBackColor = true;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(70, 210);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(75, 23);
            buttonLogin.TabIndex = 6;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += ButtonLogin_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(170, 210);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 300);
            Controls.Add(buttonCancel);
            Controls.Add(buttonLogin);
            Controls.Add(radioButtonAccount);
            Controls.Add(radioButtonClient);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(labelPassword);
            Controls.Add(labelUsername);
            Name = "LoginForm";
            Text = "Login Form";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelUsername;
        private Label labelPassword;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private RadioButton radioButtonClient;
        private RadioButton radioButtonAccount;
        private Button buttonLogin;
        private Button buttonCancel;
    }
}
