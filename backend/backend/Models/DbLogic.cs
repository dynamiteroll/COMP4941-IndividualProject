using System.Data.SqlClient;
using System.Data;

namespace backend.Models
{
    public class DbLogic
    {
        public Response register(Users users, SqlConnection conn)
        {
            Response res = new Response();

            //hashing doesn't work now, maybe sometime in the future 
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

            //hashing doesn't work now, maybe sometime in the future 
            //string hashedPassword = BCrypt.Net.BCrypt.HashPassword(users.Password);
            string queryString = "SELECT * FROM Users WHERE Email = '" + users.Email + "' AND Password = '" + users.Password + "'";
          

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(queryString, conn);
                SqlDataReader reader= cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt.Rows.Count > 0)
                {
                    res.StatusCode = 200;
                    res.StatusMessage = "User exists";
                    Users user = new Users();
                    user.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                    user.Username = Convert.ToString(dt.Rows[0]["Username"]);
                    user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                    res.user = user;
                }
                else
                {
                    res.StatusCode = 100;
                    Console.WriteLine("user not found");
                    res.StatusMessage = "User doesn't exist or isn't valid";
                    res.user = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                conn.Close();
            }


            

            return res;
        }


        //maybe in the future idk
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
    }
}
