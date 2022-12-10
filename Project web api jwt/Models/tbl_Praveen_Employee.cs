using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_web_api_jwt.Models
{
    public class tbl_Praveen_Employee
    {
        public int employeeID { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public string password { get; set; }
    }
}
