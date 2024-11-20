namespace POO_25453_TP.Login
{
    partial class LoginForm
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
            buttonClient = new Button();
            buttonAccount = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // buttonClient
            // 
            buttonClient.Location = new Point(105, 148);
            buttonClient.Name = "buttonClient";
            buttonClient.Size = new Size(121, 34);
            buttonClient.TabIndex = 0;
            buttonClient.Text = "Client";
            buttonClient.UseVisualStyleBackColor = true;
            // 
            // buttonAccount
            // 
            buttonAccount.Location = new Point(105, 285);
            buttonAccount.Name = "buttonAccount";
            buttonAccount.Size = new Size(121, 34);
            buttonAccount.TabIndex = 1;
            buttonAccount.Text = "button2";
            buttonAccount.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(224, 427);
            button3.Name = "button3";
            button3.Size = new Size(121, 34);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 473);
            Controls.Add(button3);
            Controls.Add(buttonAccount);
            Controls.Add(buttonClient);
            Name = "LoginForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonClient;
        private Button buttonAccount;
        private Button button3;
    }
}