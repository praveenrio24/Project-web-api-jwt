using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_web_api_jwt.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
