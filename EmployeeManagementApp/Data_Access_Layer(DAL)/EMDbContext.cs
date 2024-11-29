using Business_Object_Layer_BOL_;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer_DAL_
{
    public class EMDbContext:DbContext
    {
        public EMDbContext(DbContextOptions<EMDbContext> options):base(options)
        {
                
        }
        public DbSet<EmployeeInformation> EmployeeInformation { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}
