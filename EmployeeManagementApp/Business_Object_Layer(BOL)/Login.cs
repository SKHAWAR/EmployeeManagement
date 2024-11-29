using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business_Object_Layer_BOL_
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
