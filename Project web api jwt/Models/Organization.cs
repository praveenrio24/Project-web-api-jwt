using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_web_api_jwt.Models
{
    public class Organization
    {
        public int OrganizationID{ get; set; }
        public string OrganizationName { get; set; }
        public string  CreatedOn { get; set; }
        public int MyProperty { get; set; }

    }
}
