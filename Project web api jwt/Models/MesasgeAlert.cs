using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_web_api_jwt.Models
{
    public class MesasgeAlert
    {
        public string errorText { get; set; }
        public string errorCode { get; set; }
        public string fieldName { get; set; }
        public string fieldValue { get; set; }
    }
}
