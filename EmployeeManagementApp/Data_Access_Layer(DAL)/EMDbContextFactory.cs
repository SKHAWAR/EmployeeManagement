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
            optionsBuilder.UseSqlServer("Server=DESKTOP-05PKT0S;Database=EmployeeManagementSystem;Trusted_Connection=True;");
            return new EMDbContext(optionsBuilder.Options);
        }
    }
}
