namespace POO_25453_TP
{
    partial class ClientLoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonCreateAccount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelUsername = new Label();
            labelPassword = new Label();
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            buttonCreateAccount = new Button();
            SuspendLayout();
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(30, 20);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(60, 15);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "Username";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(30, 60);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(57, 15);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Password";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(120, 20);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(150, 23);
            textBoxUsername.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(120, 60);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(150, 23);
            textBoxPassword.TabIndex = 3;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(30, 100);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(100, 30);
            buttonLogin.TabIndex = 4;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonCreateAccount
            // 
            buttonCreateAccount.Location = new Point(150, 100);
            buttonCreateAccount.Name = "buttonCreateAccount";
            buttonCreateAccount.Size = new Size(120, 30);
            buttonCreateAccount.TabIndex = 5;
            buttonCreateAccount.Text = "Create Account";
            buttonCreateAccount.UseVisualStyleBackColor = true;
            buttonCreateAccount.Click += buttonCreateAccount_Click;
            // 
            // ClientLoginForm
            // 
            ClientSize = new Size(320, 160);
            Controls.Add(labelUsername);
            Controls.Add(textBoxUsername);
            Controls.Add(labelPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(buttonLogin);
            Controls.Add(buttonCreateAccount);
            Name = "ClientLoginForm";
            Text = "Client Login";
            Load += ClientLoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
