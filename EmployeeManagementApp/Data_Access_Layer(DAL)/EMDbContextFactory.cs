using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer_DAL_
{
    public class EMDbContextFactory : IDesignTimeDbContextFactory<EMDbContext>
    {
        public EMDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EMDbContext>();
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-OT3JDKD\SQLEXPRESS2008;Database=EmployeeManagementSystem;User Id=sa;Password=ahghbfgfc;");
                return new EMDbContext(optionsBuilder.Options);
        }
    }
}
