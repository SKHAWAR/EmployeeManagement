
namespace EmployeeManagementSystem
{
    partial class Admin
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
            panel1 = new System.Windows.Forms.Panel();
            button3 = new System.Windows.Forms.Button();
            AddNewEmployeBtn = new System.Windows.Forms.Button();
            GetAllEmployee = new System.Windows.Forms.Button();
            EmployeeInformationListGrid = new System.Windows.Forms.DataGridView();
            CloseBtn = new MetroFramework.Controls.MetroButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)EmployeeInformationListGrid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button3);
            panel1.Controls.Add(AddNewEmployeBtn);
            panel1.Controls.Add(GetAllEmployee);
            panel1.Location = new System.Drawing.Point(23, 86);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(188, 387);
            panel1.TabIndex = 0;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(3, 77);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(182, 36);
            button3.TabIndex = 0;
            button3.Text = "Verify Employee";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // AddNewEmployeBtn
            // 
            AddNewEmployeBtn.Location = new System.Drawing.Point(3, 40);
            AddNewEmployeBtn.Name = "AddNewEmployeBtn";
            AddNewEmployeBtn.Size = new System.Drawing.Size(182, 36);
            AddNewEmployeBtn.TabIndex = 0;
            AddNewEmployeBtn.Text = "Add New Employee";
            AddNewEmployeBtn.UseVisualStyleBackColor = true;
            AddNewEmployeBtn.Click += AddNewEmployeBtn_Click;
            // 
            // GetAllEmployee
            // 
            GetAllEmployee.Location = new System.Drawing.Point(3, 3);
            GetAllEmployee.Name = "GetAllEmployee";
            GetAllEmployee.Size = new System.Drawing.Size(182, 36);
            GetAllEmployee.TabIndex = 0;
            GetAllEmployee.Text = "Get All Employees";
            GetAllEmployee.UseVisualStyleBackColor = true;
            GetAllEmployee.Click += GetAllEmployee_Click;
            // 
            // EmployeeInformationListGrid
            // 
            EmployeeInformationListGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            EmployeeInformationListGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            EmployeeInformationListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EmployeeInformationListGrid.Location = new System.Drawing.Point(213, 86);
            EmployeeInformationListGrid.Name = "EmployeeInformationListGrid";
            EmployeeInformationListGrid.RowTemplate.Height = 25;
            EmployeeInformationListGrid.Size = new System.Drawing.Size(564, 387);
            EmployeeInformationListGrid.TabIndex = 1;
            EmployeeInformationListGrid.CellContentClick += EmployeeInformationListGrid_CellContentClick;
            // 
            // CloseBtn
            // 
            CloseBtn.BackColor = System.Drawing.Color.Brown;
            CloseBtn.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            CloseBtn.Location = new System.Drawing.Point(733, 28);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new System.Drawing.Size(44, 22);
            CloseBtn.TabIndex = 2;
            CloseBtn.Text = "X";
            CloseBtn.UseVisualStyleBackColor = false;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // Admin
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 550);
            ControlBox = false;
            Controls.Add(CloseBtn);
            Controls.Add(EmployeeInformationListGrid);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Admin";
            Text = "Admin";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)EmployeeInformationListGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button GetAllEmployee;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button AddNewEmployeBtn;
        private System.Windows.Forms.DataGridView EmployeeInformationListGrid;
        private MetroFramework.Controls.MetroButton CloseBtn;
    }
}