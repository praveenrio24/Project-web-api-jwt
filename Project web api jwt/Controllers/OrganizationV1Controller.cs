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
        public List<USP_Praveen_Organization_FetchAll> GetList(int OrganizationId, string OrganizationName)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SQLCONNECT"));
            connection.Open();
            USP_Praveen_Organization_FetchAll all = new USP_Praveen_Organization_FetchAll();
            string procedureName = "USP_Praveen_Organization_FetchAll";
            var result = new List<USP_Praveen_Organization_FetchAll>();
            using (SqlCommand command = new SqlCommand(procedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@OrganizationId",all.OrganizationID));
                command.Parameters.Add(new SqlParameter("@OrganizationName",all.OrganizationName));
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader[0].ToString());
                        string name = reader[1].ToString();
                        float? age = float.Parse(reader[2]?.ToString());
                        string Country = reader[3].ToString();
                        float? savings = float.Parse(reader[4]?.ToString());
                        USP_Praveen_Organization_FetchAll tmpRecord = new USP_Praveen_Organization_FetchAll()
                        {
                            OrganizationID = OrganizationId,
                            OrganizationName = OrganizationName,


                        };
                        result.Add(tmpRecord);
                    }
                }
            }
            return result;

        }
    }
}
              

         
