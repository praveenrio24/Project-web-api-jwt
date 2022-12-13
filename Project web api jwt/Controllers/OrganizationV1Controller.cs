using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Project_web_api_jwt.Services;
using Project_web_api_jwt.Models;
using System.Collections;

namespace Project_web_api_jwt.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationV1Controller : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public OrganizationV1Controller(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost]
        [Route("GetAllOrganization")]
        public Result GetAllOrganization()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SQLCONNECT"));
            connection.Open();
            Result result = new Result();
            List<string> list = new List<string>();
            Hashtable hashtable = new Hashtable();
            Hashtable hashtable1 = new Hashtable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select OrganizationID,OrganizationName,CreatedOn from tbl_Praveen_Organization", connection);

            DataTable table = new DataTable();
            sqlDataAdapter.Fill(table);
            tbl_Praveen_Organization tbl_Praveen = new tbl_Praveen_Organization();
            if (table != null)
            {
                hashtable.Add("getOrganization", table);
                hashtable1.Add("ErrorText", "success ");
                hashtable1.Add("ErrorCode", "successfull");
                hashtable1.Add("FieldName", "null");
                hashtable1.Add("Fieldvalue", "null");
                return new Result { rcode = 200, robj = hashtable, reqID = Guid.NewGuid(), trnID = "E - AAA0001", rmsg = hashtable1 };
            }
            else
            {
                hashtable1.Add("ErrorText", "Something went Wrong ");
                hashtable1.Add("ErrorCode", "null");
                hashtable1.Add("FieldName", "null");
                hashtable1.Add("Fieldvalue", "null");
                return new Result { rcode = 500, robj = hashtable, reqID = Guid.NewGuid(), trnID = "E - AAA0001", rmsg = hashtable1 };
            }
        }
    }
}
        

         
