using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business_Object_Layer_BOL_
{
    public class EmployeeInformation
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string ThumbPrint { get; set; }
    }
}
