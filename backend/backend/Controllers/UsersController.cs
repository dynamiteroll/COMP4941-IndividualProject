using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Cors;
using System.Diagnostics;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        [Route("register")]
        public Response register(Users users)
        {

            Response res = new Response();
            DbLogic db = new DbLogic();
            try
            {
                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("WEBAPP").ToString());


                res = db.register(users, conn);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return res;
            }


        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        [Route("login")]

        public Response login(Users users)
        {
            DbLogic db = new DbLogic();
            Response res = new Response();
            try
            {
                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("WEBAPP").ToString());


                res = db.login(users, conn);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return res;
            }
           

        }


        //for the future idk
        //[HttpPost]
        //[Route("viewUserProfile")]
        //public Response viewUserProfile(Users users) 
        //{
        //    DbLogic db = new DbLogic();
        //    SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("WebAppCS").ToString());
        //    Response res = db.viewUserProfile(users, conn);
        //    return res;
        //} 

        //[HttpPost]
        //[Route("updateUser")]

        //public Response updateUser(Users users)
        //{
        //    DbLogic db = new DbLogic();
        //    SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("WebAppCS").ToString());
        //    Response res = db.updateUser(users, conn);
        //    return res;
        //}

    }
}
