
namespace EmployeeManagementSystem
{
    partial class Login
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            UsernameTextbox = new System.Windows.Forms.TextBox();
            PasswordTextbox = new System.Windows.Forms.TextBox();
            LoginBtn = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(82, 90);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(87, 21);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(84, 172);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(82, 21);
            label2.TabIndex = 1;
            label2.Text = "Password";
            label2.Click += label2_Click;
            // 
            // UsernameTextbox
            // 
            UsernameTextbox.Location = new System.Drawing.Point(89, 129);
            UsernameTextbox.Name = "UsernameTextbox";
            UsernameTextbox.Size = new System.Drawing.Size(205, 23);
            UsernameTextbox.TabIndex = 2;
            // 
            // PasswordTextbox
            // 
            PasswordTextbox.Location = new System.Drawing.Point(89, 211);
            PasswordTextbox.Name = "PasswordTextbox";
            PasswordTextbox.Size = new System.Drawing.Size(205, 23);
            PasswordTextbox.TabIndex = 3;
            PasswordTextbox.TextChanged += textBox2_TextChanged;
            // 
            // LoginBtn
            // 
            LoginBtn.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
            LoginBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            LoginBtn.Location = new System.Drawing.Point(89, 262);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new System.Drawing.Size(205, 31);
            LoginBtn.TabIndex = 4;
            LoginBtn.Text = "Login";
            LoginBtn.UseVisualStyleBackColor = false;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(400, 450);
            Controls.Add(LoginBtn);
            Controls.Add(PasswordTextbox);
            Controls.Add(UsernameTextbox);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Login";
            Text = "Login";
            Load += Admin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.Button LoginBtn;
    }
}