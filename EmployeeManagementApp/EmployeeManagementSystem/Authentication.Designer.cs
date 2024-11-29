namespace EmployeeManagementSystem
{
    partial class Authentication
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
            cboReaders = new System.Windows.Forms.ComboBox();
            pbFingerprint = new System.Windows.Forms.PictureBox();
            EmployeeNameTextBox = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pbFingerprint).BeginInit();
            SuspendLayout();
            // 
            // cboReaders
            // 
            cboReaders.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboReaders.Location = new System.Drawing.Point(62, 193);
            cboReaders.Name = "cboReaders";
            cboReaders.Size = new System.Drawing.Size(168, 21);
            cboReaders.TabIndex = 22;
            // 
            // pbFingerprint
            // 
            pbFingerprint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pbFingerprint.Location = new System.Drawing.Point(253, 77);
            pbFingerprint.Name = "pbFingerprint";
            pbFingerprint.Size = new System.Drawing.Size(145, 142);
            pbFingerprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbFingerprint.TabIndex = 21;
            pbFingerprint.TabStop = false;
            // 
            // EmployeeNameTextBox
            // 
            EmployeeNameTextBox.Location = new System.Drawing.Point(62, 109);
            EmployeeNameTextBox.Name = "EmployeeNameTextBox";
            EmployeeNameTextBox.Size = new System.Drawing.Size(168, 23);
            EmployeeNameTextBox.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(56, 150);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(101, 21);
            label2.TabIndex = 17;
            label2.Text = "ThumbPrint";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(56, 72);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(136, 21);
            label1.TabIndex = 18;
            label1.Text = "Employee Name";
            // 
            // Authentication
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(455, 294);
            Controls.Add(cboReaders);
            Controls.Add(pbFingerprint);
            Controls.Add(EmployeeNameTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Authentication";
            Text = "Authentication";
            Load += Authentication_Load;
            ((System.ComponentModel.ISupportInitialize)pbFingerprint).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal System.Windows.Forms.ComboBox cboReaders;
        internal System.Windows.Forms.PictureBox pbFingerprint;
        private System.Windows.Forms.TextBox EmployeeNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}