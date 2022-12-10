using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Project_web_api_jwt.DataAccessLayer;
using Project_web_api_jwt.Models;
using Project_web_api_jwt.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_web_api_jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Accountv1Controller : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IJwtTokenGeneration _jwtTokenGeneration;


        public Accountv1Controller(IConfiguration configuration, IJwtTokenGeneration jwtTokenGeneration)
        {
            _configuration = configuration;
            _jwtTokenGeneration = jwtTokenGeneration;
        }
        [HttpPost]
        [Route("login")]
        public Result Login(Login login)
        {
            Result result = new Result();
            Hashta
            


            try
            {
                if (login.Email == null)
                {
                    result.rcode = 501;
                    result.reqID = Guid.NewGuid();
                    result.trnID = "E-AAA0001";
                   
                }
                else
                {
                    if (login.PasswordHash == null)
                    {
                        result.rcode = 500;
                        result.reqID = Guid.NewGuid();
                        result.trnID = "E-AAA0001";
                       

                    }
                    else
                    {
                        string email = login.Email;
                        Regex regex = new Regex(@"^[a-zA-Z0-9]{5,10}(@gmail.com){1}$");
                        Match match = regex.Match(email);

                        if (!match.Success)
                        {
                            result.rcode = 500;
                            result.reqID = Guid.NewGuid();
                            result.trnID = "E-AAA0001";
                          

                        }
                        else
                        {
                            string password = login.PasswordHash;
                            Regex regex1 = new Regex(@"^[a-zA-Z0-9]{3,10}[@]{1}[0-9]{1,7}$");
                            Match match1 = regex1.Match(password);
                            if (!match1.Success)
                            {
                                result.rcode = 500;
                                result.reqID = Guid.NewGuid();
                                result.trnID = "E-AAA0001";
                                
                              


                            }
                            {
                                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("SQLCONNECT").ToString());
                               
                                AccessLayer accessLayer = new AccessLayer(_configuration, _jwtTokenGeneration);
                                result = accessLayer.Login(con,login);


                            }
                        }


                    }
                }
            }
            catch (Exception e)
            {
                return new Result{ reqID= Guid.NewGuid() };
            }
            return result;

        }
        
    }
}
