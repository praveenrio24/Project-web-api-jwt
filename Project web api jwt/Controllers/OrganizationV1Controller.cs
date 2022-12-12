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
        public OrganizationV1Controller(IConfiguration configuration, IJwtTokenGeneration jwtTokenGeneration)
        {
            _configuration = configuration;
        }

       
        [HttpPost]
        [Route("GetOrganization")]

        
        public List<USP_Praveen_Organization_FetchAll> GetList()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SQLCONNECT"));
            connection.Open();
            USP_Praveen_Organization_FetchAll all = new USP_Praveen_Organization_FetchAll();
            string procedureName = "USP_Praveen_Organization_FetchAll   ";
            var result = new List<USP_Praveen_Organization_FetchAll>();
            SqlDataAdapter da = new SqlDataAdapter(procedureName, connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
        
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<USP_Praveen_Organization_FetchAll> list1 = new List<USP_Praveen_Organization_FetchAll>();
            if(dt.Rows.Count>0)                         
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    all.OrganizationID = Convert.ToInt32(dt.Rows[i]["OrganizationID"]);
                    all.OrganizationName = dt.Rows[i]["OrganizationName"].ToString();
                    list1.Add(all);
                }

                
            }
            if(list1 !=null)
            {
                return list1;
            }
            else
            {
                return null;
            }

        }
    }
}
              

         
