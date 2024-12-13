using Business_Logic_Layer;
using Business_Object_Layer_BOL_;
using Data_Access_Layer_DAL_;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public static class Program
    {
        public static ServiceProvider ServiceProvider;

        [STAThread]
        static void Main()
        {
            ServiceProvider = new ServiceCollection()
               .AddDbContext<EMDbContext>(options =>
                   options.UseSqlServer(@"Server=DESKTOP-OT3JDKD\SQLEXPRESS2008;Database=EmployeeManagementSystem;User Id=sa;Password=ahghbfgfc;")) // Replace with your actual connection string
               .AddTransient<ILoginDb, LoginDb>()
               .AddTransient<ILoginBs, LoginBs>()
               .AddTransient<IEmployeeInformationDb, EmployeeInformationDb>()
               .AddTransient<IEmployeeInformationBs, EmployeeInformationBs>()
               .AddTransient<Login>()  
               .AddTransient<EmployeeInformation>()
               .BuildServiceProvider();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var loginForm = ServiceProvider.GetRequiredService<Login>();
            Application.Run(loginForm);
        }
    }
}
