using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_web_api_jwt.Models
{
    public class USP_Praveen_Organization_Fetch
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifyOn { get; set; }
        public string ModifyBy { get; set; }
        public bool IsActive { get; set; }
    }
}
