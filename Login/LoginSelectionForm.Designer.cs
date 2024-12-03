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
            this.buttonAdmin = new System.Windows.Forms.Button();
            this.buttonClient = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // buttonAdmin
            this.buttonAdmin.Location = new System.Drawing.Point(50, 30);
            this.buttonAdmin.Name = "buttonAdmin";
            this.buttonAdmin.Size = new System.Drawing.Size(150, 40);
            this.buttonAdmin.Text = "Admin Login";
            this.buttonAdmin.UseVisualStyleBackColor = true;
            this.buttonAdmin.Click += new System.EventHandler(this.buttonAdmin_Click);

            // buttonClient
            this.buttonClient.Location = new System.Drawing.Point(50, 90);
            this.buttonClient.Name = "buttonClient";
            this.buttonClient.Size = new System.Drawing.Size(150, 40);
            this.buttonClient.Text = "Client Login";
            this.buttonClient.UseVisualStyleBackColor = true;
            this.buttonClient.Click += new System.EventHandler(this.buttonClient_Click);

            // LoginSelectionForm
            this.ClientSize = new System.Drawing.Size(250, 180);
            this.Controls.Add(this.buttonAdmin);
            this.Controls.Add(this.buttonClient);
            this.Name = "LoginSelectionForm";
            this.Text = "Login Selection";
            this.ResumeLayout(false);
        }
    }
}
