using Business_Logic_Layer;
using Business_Object_Layer_BOL_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class Admin : MetroFramework.Forms.MetroForm
    {
        private readonly IEmployeeInformationBs employeeInformationBs;
        public Admin(IEmployeeInformationBs _employeeInformationBs)
        {
            employeeInformationBs = _employeeInformationBs;
            InitializeComponent();
            var employeeData = employeeInformationBs.GetAll();
            this.EmployeeInformationListGrid.DataSource = employeeData;
        }
        private void EmployeeInformationListGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void GetAllEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                var employeeData = employeeInformationBs.GetAll();
                this.EmployeeInformationListGrid.DataSource = employeeData;
            }
            catch (Exception Ex)
            {
            }
        }
        private void AddNewEmployeBtn_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is AddEmployee)
                {
                    f.BringToFront();
                    f.Activate();
                    return;
                }
            }
            var employeeInformationBs = Program.ServiceProvider.GetRequiredService<IEmployeeInformationBs>();
            AddEmployee addnewEmployee = new AddEmployee(employeeInformationBs);
            addnewEmployee.Show();
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is AddEmployee)
                {
                    f.BringToFront();
                    f.Activate();
                    return;
                }
            }
            var employeeInformationBs = Program.ServiceProvider.GetRequiredService<IEmployeeInformationBs>();
            Authentication authentication = new Authentication(employeeInformationBs);
            authentication.Show();
        }
    }
}
