namespace POO_25453_TP
{
    partial class AddAccountForm
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
            Addbuton = new Button();
            label1 = new Label();
            label2 = new Label();
            textBoxPassword = new TextBox();
            textBoxUsername = new TextBox();
            label3 = new Label();
            textBoxName = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // Addbuton
            // 
            Addbuton.Location = new Point(537, 305);
            Addbuton.Name = "Addbuton";
            Addbuton.Size = new Size(75, 23);
            Addbuton.TabIndex = 0;
            Addbuton.Text = "Add";
            Addbuton.UseVisualStyleBackColor = true;
            Addbuton.Click += Addbuton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(172, 240);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 1;
            label1.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(169, 141);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(235, 237);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(232, 23);
            textBoxPassword.TabIndex = 3;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(235, 138);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(232, 23);
            textBoxUsername.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(190, 54);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 5;
            label3.Text = "Name";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(235, 51);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(232, 23);
            textBoxName.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(618, 305);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            // 
            // AddAccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(763, 350);
            Controls.Add(button1);
            Controls.Add(textBoxName);
            Controls.Add(label3);
            Controls.Add(textBoxUsername);
            Controls.Add(textBoxPassword);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Addbuton);
            Name = "AddAccountForm";
            Text = "AddAccountForm";
            Load += AddAccountForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Addbuton;
        private Label label1;
        private Label label2;
        private TextBox textBoxPassword;
        private TextBox textBoxUsername;
        private Label label3;
        private TextBox textBoxName;
        private Button button1;
    }
}