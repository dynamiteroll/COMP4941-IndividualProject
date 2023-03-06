using System.Data.SqlClient;
using System.Data;
using backend.Controllers;

namespace backend.Models
{
    public class DbLogic
    {
        // supposed to be for session variables, but doesn't work
        //private readonly IHttpContextAccessor context;

        public Response register(Users users, SqlConnection conn)
        {
            Response res = new Response();

            //hashing currently doesn't work
            //string hashedPassword = BCrypt.Net.BCrypt.HashPassword(users.Password);

            string queryString = "INSERT INTO Users(Username, Email, Password) VALUES('" + users.Username + "','" + users.Email + "','" + users.Password + "')";

            SqlCommand cmd = new SqlCommand(queryString, conn);
            conn.Open();

            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                res.StatusCode = 200;
                res.StatusMessage = "User registration success";
            }
            else
            {
                res.StatusCode = 100;
                res.StatusMessage = "User registration failed";
            }

            return res;
        }

        public Response login(Users users, SqlConnection conn)
        {
            Response res = new Response();

            //hashing doesn't currently work
            //string hashedPassword = BCrypt.Net.BCrypt.HashPassword(users.Password);

            string queryString = "SELECT * FROM Users WHERE Email = '" + users.Email + "' AND Password = '" + users.Password + "'";
          

            try
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(queryString, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    res.StatusCode = 200;
                    res.StatusMessage = "User exists";
                    Users user = new Users();
                    user.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                    user.Username = Convert.ToString(dt.Rows[0]["Username"]);
                    user.Email = Convert.ToString(dt.Rows[0]["Email"]);


                    // for session variables, currently doesn't work
                    //string username = user.Username;
                    //SessionController sc = new SessionController((HttpContextAccessor)context);
                    //IEnumerable<string> session = sc.GetSessionInfo(username);

                    //res.Session = (SessionVariables)session;
                    res.User = user;
                }
                else
                {
                    res.StatusCode = 100;
                    Console.WriteLine("user not found");
                    res.StatusMessage = "User doesn't exist or isn't valid";
                    res.User = null;
                }
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                conn.Close();
                return res;
            }
            
        }

        // possible future feature
        //public Response viewUserProfile(Users users, SqlConnection conn)
        //{
        //    SqlDataAdapter da = new SqlDataAdapter("p_viewUserProfile", conn);
        //    da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    da.SelectCommand.Parameters.AddWithValue("@ID", users.UserID);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    Response res = new Response();
        //    Users user = new Users();

        //    if (dt.Rows.Count > 0)
        //    {
        //        user.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
        //        user.Username = Convert.ToString(dt.Rows[0]["Username"]);
        //        user.Email = Convert.ToString(dt.Rows[0]["Email"]);
        //        user.Password = Convert.ToString(dt.Rows[0]["Password"]);
        //        res.StatusCode = 200;
        //        res.StatusMessage = "User exists";

        //    }
        //    else
        //    {
        //        res.StatusCode = 100;
        //        res.StatusMessage = "User doesn't exist";
        //        res.user = user;
        //    }

        //    return res;

        //}

        //public Response updateUser(Users users, SqlConnection conn)
        //{
        //    Response res = new Response();

        //    SqlCommand cmd = new SqlCommand("sp_updateUser", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Username", users.Username);
        //    cmd.Parameters.AddWithValue("@Email", users.Email);
        //    cmd.Parameters.AddWithValue("@Password", users.Password);
        //    conn.Open();

        //    int i = cmd.ExecuteNonQuery();
        //    conn.Close();

        //    if (i > 0)
        //    {
        //        res.StatusCode = 200;
        //        res.StatusMessage = "User details updated";
        //    }
        //    else 
        //    {
        //        res.StatusCode = 100;
        //        res.StatusMessage = "Failed to update details, please try again";
        //    }

        //    return res;

        //}

        public Response addMovie(Movie movie, SqlConnection conn)
        {
            Response res = new Response();

            string queryString = "INSERT INTO Movie(UserID, MovieID, Poster, Title, Year) VALUES('" + movie.UserID + "','" + movie.MovieID + "','" + movie.Poster + 
                "','" + movie.Title + "','" + movie.Year + "')";


            SqlCommand cmd = new SqlCommand(queryString, conn);
            conn.Open();

            int i = cmd.ExecuteNonQuery();

            conn.Close();
            if (i > 0)
            {
                res.StatusCode = 200;
                res.StatusMessage = "Movie added successfully";
                res.Movie = movie;
            }
            else
            {
                res.StatusCode = 100;
                res.StatusMessage = "Add movie failed: request to the server failed";
            }

            return res;
        }

        public Response getMovies(string UserID, SqlConnection conn) 
        {
            Response res = new Response();
            string queryString = "SELECT * FROM Movie where UserID = '" + UserID + "'";


            try
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(queryString, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);


                List<Movie> list = new List<Movie>();


                if (dt.Rows.Count > 0)
                {
                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Movie movie = new Movie();
                        movie.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
                        movie.MovieID = Convert.ToString(dt.Rows[i]["MovieID"]);
                        movie.Poster = Convert.ToString(dt.Rows[i]["Poster"]);
                        movie.Title = Convert.ToString(dt.Rows[i]["Title"]);
                        movie.Year = Convert.ToInt32(dt.Rows[i]["Year"]);
                        list.Add(movie);
                    }


                        res.StatusCode = 200;
                        res.StatusMessage = "Movie data fetched";
                        res.MovieList = list;
                    

                }
                else
                {
                    res.StatusCode = 100;
                    res.StatusMessage = "No movies found";
                    res.MovieList = null;
                }
                conn.Close();
                return res;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                conn.Close();

                return res;
            }


        }

        public Response deleteMovie(Movie movie, SqlConnection conn)
        {
            Response res = new Response();
            string queryString = "DELETE FROM Movie WHERE UserID = '" + movie.UserID + "' AND MovieID = '" + movie.MovieID + "'";

            SqlCommand cmd = new SqlCommand(queryString, conn);
            conn.Open();

            int i = cmd.ExecuteNonQuery();

            conn.Close();
            if (i > 0)
            {
                res.StatusCode = 200;
                res.StatusMessage = "Movie deleted successfully";
                res.Movie = movie;
            }
            else
            {
                res.StatusCode = 100;
                res.StatusMessage = "Delete movie failed: request to the server failed";
            }

            return res;
        }




    }
}
