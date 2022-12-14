using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftAntE2Office.Praveen.WebAPI.Models
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
