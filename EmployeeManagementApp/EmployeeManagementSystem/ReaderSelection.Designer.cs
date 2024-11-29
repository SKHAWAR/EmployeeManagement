namespace UareUSampleCSharp
{
    partial class ReaderSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false</param>
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
            btnBack = new System.Windows.Forms.Button();
            btnSelect = new System.Windows.Forms.Button();
            btnCaps = new System.Windows.Forms.Button();
            btnRefresh = new System.Windows.Forms.Button();
            cboReaders = new System.Windows.Forms.ComboBox();
            lblSelectReader = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new System.Drawing.Point(133, 81);
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(115, 23);
            btnBack.TabIndex = 18;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            // 
            // btnSelect
            // 
            btnSelect.Enabled = false;
            btnSelect.Location = new System.Drawing.Point(12, 81);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new System.Drawing.Size(115, 23);
            btnSelect.TabIndex = 17;
            btnSelect.Text = "Select";
            btnSelect.Click += btnReaderSelect_Click;
            // 
            // btnCaps
            // 
            btnCaps.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnCaps.Enabled = false;
            btnCaps.Location = new System.Drawing.Point(133, 52);
            btnCaps.Name = "btnCaps";
            btnCaps.Size = new System.Drawing.Size(115, 23);
            btnCaps.TabIndex = 16;
            btnCaps.Text = "Capabilities";
            btnCaps.Click += btnCaps_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new System.Drawing.Point(12, 52);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(115, 23);
            btnRefresh.TabIndex = 15;
            btnRefresh.Text = "Refresh List";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // cboReaders
            // 
            cboReaders.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboReaders.Location = new System.Drawing.Point(12, 25);
            cboReaders.Name = "cboReaders";
            cboReaders.Size = new System.Drawing.Size(256, 21);
            cboReaders.TabIndex = 14;
            // 
            // lblSelectReader
            // 
            lblSelectReader.Location = new System.Drawing.Point(12, 9);
            lblSelectReader.Name = "lblSelectReader";
            lblSelectReader.Size = new System.Drawing.Size(296, 13);
            lblSelectReader.TabIndex = 13;
            lblSelectReader.Text = "Select Reader:";
            lblSelectReader.Click += lblSelectReader_Click;
            // 
            // ReaderSelection
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            ClientSize = new System.Drawing.Size(296, 120);
            Controls.Add(btnBack);
            Controls.Add(btnSelect);
            Controls.Add(btnCaps);
            Controls.Add(btnRefresh);
            Controls.Add(cboReaders);
            Controls.Add(lblSelectReader);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(312, 159);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(312, 159);
            Name = "ReaderSelection";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Select Reader";
            Load += ReaderSelection_Load;
            ResumeLayout(false);
        }

        #endregion

        internal System.Windows.Forms.Button btnBack;
        internal System.Windows.Forms.Button btnSelect;
        internal System.Windows.Forms.Button btnCaps;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.ComboBox cboReaders;
        internal System.Windows.Forms.Label lblSelectReader;
    }
}