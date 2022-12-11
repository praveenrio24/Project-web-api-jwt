using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_web_api_jwt.Models
{
    public class Result
    {
        public int rcode { get; set; }
        public Guid reqID { get; set; }
        public string trnID { get; set; }

        public  Object robj { get; set; }

       public object rmsg { get; set; }



    }

}
