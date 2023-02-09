namespace backend.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        //might need this when searching for users later on
        public List<Users> listUsers { get; set; }

        public Users user { get; set; }

        //eventually will add more for the movies part
    }
}
