
namespace EmployeeManagementSystem
{
    partial class AddEmployee
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
            EmployeeNameTextBox = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            btnBack = new System.Windows.Forms.Button();
            pbFingerprint = new System.Windows.Forms.PictureBox();
            cboReaders = new System.Windows.Forms.ComboBox();
            lblSelectReader = new System.Windows.Forms.Label();
            button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pbFingerprint).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(45, 78);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(136, 21);
            label1.TabIndex = 0;
            label1.Text = "Employee Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(45, 156);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(101, 21);
            label2.TabIndex = 0;
            label2.Text = "ThumbPrint";
            label2.Click += label2_Click;
            // 
            // EmployeeNameTextBox
            // 
            EmployeeNameTextBox.Location = new System.Drawing.Point(51, 115);
            EmployeeNameTextBox.Name = "EmployeeNameTextBox";
            EmployeeNameTextBox.Size = new System.Drawing.Size(168, 23);
            EmployeeNameTextBox.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
            button1.Location = new System.Drawing.Point(50, 257);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(169, 30);
            button1.TabIndex = 2;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new System.Drawing.Point(322, 257);
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(61, 30);
            btnBack.TabIndex = 7;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            // 
            // pbFingerprint
            // 
            pbFingerprint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pbFingerprint.Location = new System.Drawing.Point(242, 83);
            pbFingerprint.Name = "pbFingerprint";
            pbFingerprint.Size = new System.Drawing.Size(145, 142);
            pbFingerprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbFingerprint.TabIndex = 9;
            pbFingerprint.TabStop = false;
            pbFingerprint.Click += pbFingerprint_Click;
            // 
            // cboReaders
            // 
            cboReaders.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboReaders.Location = new System.Drawing.Point(51, 199);
            cboReaders.Name = "cboReaders";
            cboReaders.Size = new System.Drawing.Size(168, 21);
            cboReaders.TabIndex = 16;
            // 
            // lblSelectReader
            // 
            lblSelectReader.Location = new System.Drawing.Point(239, 265);
            lblSelectReader.Name = "lblSelectReader";
            lblSelectReader.Size = new System.Drawing.Size(80, 17);
            lblSelectReader.TabIndex = 15;
            lblSelectReader.Text = "Select Reader:";
            lblSelectReader.Click += lblSelectReader_Click;
            // 
            // button2
            // 
            button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button2.Location = new System.Drawing.Point(383, 26);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(34, 29);
            button2.TabIndex = 17;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // AddEmployee
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(429, 350);
            ControlBox = false;
            Controls.Add(button2);
            Controls.Add(cboReaders);
            Controls.Add(lblSelectReader);
            Controls.Add(btnBack);
            Controls.Add(pbFingerprint);
            Controls.Add(button1);
            Controls.Add(EmployeeNameTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddEmployee";
            Text = "AddEmployee";
            FormClosing += AddEmployee_FormClosing;
            Load += AddEmployee_Load;
            ((System.ComponentModel.ISupportInitialize)pbFingerprint).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EmployeeNameTextBox;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button btnBack;
        internal System.Windows.Forms.PictureBox pbFingerprint;
        internal System.Windows.Forms.ComboBox cboReaders;
        internal System.Windows.Forms.Label lblSelectReader;
        private System.Windows.Forms.Button button2;
    }
}