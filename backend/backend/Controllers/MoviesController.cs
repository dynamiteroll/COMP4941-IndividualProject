using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Cors;
using System.Diagnostics;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MoviesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        [Route("addmovie")]
        public Response addMovie(Movie movie)
        {
            Response res = new Response();
            DbLogic db = new DbLogic();

            try
            {
                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("WEBAPP").ToString());


                res = db.addMovie(movie, conn);
                return res;
            }
            catch (SqlException sqlex)
            {

                Console.WriteLine(sqlex.ToString());
                res = new Response();
                res.StatusCode = 409;
                res.StatusMessage = "Add movie failed: movie already added to list or database failed";

                return res;
            }
            catch (Exception ex)
            {
                res = new Response();
                res.StatusCode = 500;
                res.StatusMessage = "Add movie failed: something wrong occured in the server";
                Console.WriteLine(ex.ToString());
                return res;
            }

        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        [Route("getmovies")]
        public Response getMovies(string UserID)
        {
            Response res = new Response();
            DbLogic db = new DbLogic();

            try
            {
                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("WEBAPP").ToString());
                res = db.getMovies(UserID, conn);

                return res;

            }
            catch (Exception ex)
            {
                res = new Response();
                res.StatusCode = 500;
                res.StatusMessage = "failed to get movies";
                Console.WriteLine(ex.ToString());
                return res;
            }


        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        [Route("deletemovie")]
        public Response deleteMovie(Movie movie)
        {
            Response res = new Response();
            DbLogic db = new DbLogic();

            try
            {
                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("WEBAPP").ToString());
                res = db.deleteMovie(movie, conn);

                return res;

            } catch (Exception ex)
            {
                res = new Response();
                res.StatusCode = 500;
                res.StatusMessage = "failed to delete movie";
                Console.WriteLine(ex.ToString());
                return res;
            }
        }

    }
}
