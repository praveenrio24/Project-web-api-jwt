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

        
        public List<USP_Praveen_Organization_FetchAll> GetList(USP_Praveen_Organization_FetchAll all)
        {
            bool IsSuccess = true;
            string ErrorMessage = null;
            DateTime StartDate = DateTime.UtcNow;
            List<USP_Praveen_Organization_FetchAll> outputData = null;
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SQLCONNECT"));
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("USP_Praveen_Organization_FetchAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@OrganizationID",all.OrganizationID));
                command.Parameters.Add(new SqlParameter("@OrganizationName",all.OrganizationName));
                IDataReader iDr = command.ExecuteReader();
                outputData = DataReaderMapToList<USP_Praveen_Organization_FetchAll>(iDr);
                return outputData;
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
         

        }

        private List<T> DataReaderMapToList<T>(object iDR)
        {
            throw new NotImplementedException();
        }
    }
}
              

         
