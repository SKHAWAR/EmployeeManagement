using Business_Logic_Layer;
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
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        private readonly ILoginBs loginBs;
        public Login(ILoginBs _loginBs)
        {
            loginBs = _loginBs;
            InitializeComponent();
            this.MaximizeBox = false; 
            this.MinimizeBox = false;
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoginBtn_Click(object sender, EventArgs e)
        {
           bool value= loginBs.IsSerValid(UsernameTextbox.Text,PasswordTextbox.Text);
            if (value==true)
            {
                var employeeInformationBs = Program.ServiceProvider.GetRequiredService<IEmployeeInformationBs>();
                Admin admin = new Admin(employeeInformationBs);
                admin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username Or Password Is invalid");
            }
       
        }
    }
}
