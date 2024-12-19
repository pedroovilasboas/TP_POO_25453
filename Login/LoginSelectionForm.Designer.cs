namespace POO_25453_TP
{
    partial class LoginSelectionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonAdmin;
        private System.Windows.Forms.Button buttonClient;

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
            buttonAdmin = new Button();
            buttonClient = new Button();
            SuspendLayout();
            // 
            // buttonAdmin
            // 
            buttonAdmin.Location = new Point(50, 30);
            buttonAdmin.Name = "buttonAdmin";
            buttonAdmin.Size = new Size(150, 40);
            buttonAdmin.TabIndex = 0;
            buttonAdmin.Text = "Admin Page";
            buttonAdmin.UseVisualStyleBackColor = true;
            buttonAdmin.Click += buttonAdmin_Click;
            // 
            // buttonClient
            // 
            buttonClient.Location = new Point(50, 90);
            buttonClient.Name = "buttonClient";
            buttonClient.Size = new Size(150, 40);
            buttonClient.TabIndex = 1;
            buttonClient.Text = "Customer Page";
            buttonClient.UseVisualStyleBackColor = true;
            buttonClient.Click += buttonClient_Click;
            // 
            // LoginSelectionForm
            // 
            ClientSize = new Size(250, 180);
            Controls.Add(buttonAdmin);
            Controls.Add(buttonClient);
            Name = "LoginSelectionForm";
            Text = "Login Selection";
            Load += LoginSelectionForm_Load;
            ResumeLayout(false);
        }
    }
}
