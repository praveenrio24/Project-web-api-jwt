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
        private readonly IJwtTokenGeneration _jwtTokenGeneration;
        public OrganizationV1Controller(IConfiguration configuration,IJwtTokenGeneration jwtTokenGeneration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("GetOrganization")]
        public USP_Praveen_Organization_FetchAll Login(int OrganizationId,string OrganizationName)

           {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("SQLCONNECT"));
            Result result = new Result();
         
            tbl_Praveen_Employee tbl = new tbl_Praveen_Employee();
            Hashtable hashtable = new Hashtable();
            Hashtable hashtable1 = new Hashtable();
            DateTime StartDate = DateTime.UtcNow;
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("USP_Praveen_Organization_FetchAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OrganizationId", OrganizationId));
                cmd.Parameters.Add(new SqlParameter("@OrganizationName", OrganizationName));

                IDataReader idr = cmd.ExecuteReader();
                USP_Praveen_Organization_FetchAll datatable = new USP_Praveen_Organization_FetchAll();
                datatable = DataReaderMapToObject<USP_Praveen_Organization_FetchAll>(idr);
                return datatable;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        
               


        }

        private T DataReaderMapToObject<T>(IDataReader idr)
        {
            throw new NotImplementedException();
        }
    }

   
}
