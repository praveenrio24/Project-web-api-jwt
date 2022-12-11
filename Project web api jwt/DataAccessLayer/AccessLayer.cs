using Project_web_api_jwt.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Project_web_api_jwt.Services;
using Microsoft.Extensions.Configuration;
using System.Collections;

namespace Project_web_api_jwt.DataAccessLayer
{
    public class AccessLayer
    {
        private readonly IConfiguration _configuration;
        private readonly IJwtTokenGeneration _jwtTokenGeneration;
       


        public AccessLayer(IConfiguration configuration, IJwtTokenGeneration jwtTokenGeneration)
        {
            _configuration = configuration;

            _jwtTokenGeneration = jwtTokenGeneration;


        }
        public Result Login(SqlConnection con,Login login)
        {
            JwtTokenGeneration jwtTokenGeneration = new JwtTokenGeneration(_configuration);
            Result result = new Result();
            tbl_Praveen_Employee tbl = new tbl_Praveen_Employee();
            List<string> list = new List<string>();
            Hashtable hashtable = new Hashtable();
            Hashtable hashtable1 = new Hashtable();
           
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_Praveen_Employee WHERE Email = '" + login.Email + "' ", con);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            if (dt.Rows.Count>0)
            {
                tbl.firstName = dt.Rows[0]["FirstName"].ToString();
                tbl.lastName = dt.Rows[0]["LastName"].ToString();
               tbl.email = dt.Rows[0]["Email"].ToString();
               tbl.password = dt.Rows[0]["PasswordHash"].ToString();

                if (tbl.password == login.PasswordHash)
                {
                    string token = jwtTokenGeneration.Authenticate(login.Email);
                    hashtable.Add("token", token);
                    hashtable.Add("firstName", tbl.firstName);
                    hashtable.Add("lastName", tbl.lastName);
                    hashtable.Add("email", tbl.email);
                    hashtable1.Add("ErrorText", "success ");
                    hashtable1.Add("ErrorCode", "successfull");
                    hashtable1.Add("FieldName", "null");
                    hashtable1.Add("Fielvalue", "null");
                    


                    return new Result { rcode = 200, robj = hashtable, reqID = Guid.NewGuid(),rmsg=hashtable1 };

                }
                else
                {
                    result.rcode = 500;
                    result.reqID = Guid.NewGuid();
                    result.trnID = "E-AAA0001";
                    result.robj = null;
                    hashtable1.Add("ErrorText", "ERR10001");
                    hashtable1.Add("ErrorCode", "Something went wrong");
                    hashtable1.Add("FieldName", "null");
                    hashtable1.Add("Fielvalue", "null");
                    result.rmsg = hashtable1;

                }

               


            }
            else
            {
                result.rcode = 500;
                result.reqID = Guid.NewGuid();
                result.trnID = "E-AAA0001";
                result.robj = null;
                

            }
            return result;
        }
    }
}
