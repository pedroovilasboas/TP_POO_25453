namespace POO_25453_TP

{ 
    partial class EditAccountForm
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
            textBoxName = new TextBox();
            labelEditName = new Label();
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            labelEditUsername = new Label();
            labelNewPassword = new Label();
            Savebuton = new Button();
            buttonClose = new Button();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(70, 74);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(232, 23);
            textBoxName.TabIndex = 13;
            // 
            // labelEditName
            // 
            labelEditName.AutoSize = true;
            labelEditName.Location = new Point(72, 45);
            labelEditName.Name = "labelEditName";
            labelEditName.Size = new Size(62, 15);
            labelEditName.TabIndex = 12;
            labelEditName.Text = "Edit Name";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(70, 161);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(232, 23);
            textBoxUsername.TabIndex = 11;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(70, 260);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(232, 23);
            textBoxPassword.TabIndex = 10;
            // 
            // labelEditUsername
            // 
            labelEditUsername.AutoSize = true;
            labelEditUsername.Location = new Point(70, 133);
            labelEditUsername.Name = "labelEditUsername";
            labelEditUsername.Size = new Size(83, 15);
            labelEditUsername.TabIndex = 9;
            labelEditUsername.Text = "Edit Username";
            // 
            // labelNewPassword
            // 
            labelNewPassword.AutoSize = true;
            labelNewPassword.Location = new Point(70, 224);
            labelNewPassword.Name = "labelNewPassword";
            labelNewPassword.Size = new Size(84, 15);
            labelNewPassword.TabIndex = 8;
            labelNewPassword.Text = "New Password";
            // 
            // Savebuton
            // 
            Savebuton.Location = new Point(131, 376);
            Savebuton.Name = "Savebuton";
            Savebuton.Size = new Size(75, 23);
            Savebuton.TabIndex = 7;
            Savebuton.Text = "Save";
            Savebuton.UseVisualStyleBackColor = true;
            Savebuton.Click += Savebuton_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(227, 376);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(75, 23);
            buttonClose.TabIndex = 14;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // EditAccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 451);
            Controls.Add(buttonClose);
            Controls.Add(textBoxName);
            Controls.Add(labelEditName);
            Controls.Add(textBoxUsername);
            Controls.Add(textBoxPassword);
            Controls.Add(labelEditUsername);
            Controls.Add(labelNewPassword);
            Controls.Add(Savebuton);
            Name = "EditAccountForm";
            Text = "EditAccountForm";
            Load += EditAccountForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private Label labelEditName;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Label labelEditUsername;
        private Label labelNewPassword;
        private Button Savebuton;
        private Button buttonClose;
    }
}