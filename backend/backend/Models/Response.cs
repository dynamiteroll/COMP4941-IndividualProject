namespace backend.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public Users User { get; set; }

        //for the future probably
        //public List<Users> listUsers { get; set; }

        //for session variables, currently doesn't work
        //public SessionVariables Session { get; set; }

        public Movie Movie { get; set; }

        public List<Movie> MovieList { get; set; }
    }
}
