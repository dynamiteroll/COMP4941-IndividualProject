using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Movie
    {
        [ForeignKey("Users")]
        [Key, Column(Order = 0)]
        public int UserID { get; set; }
        [Key, Column(Order = 1)]
        public string MovieID { get; set; }
        public string? Poster { get; set; }
        public string? Title { get; set; }
        public int Year { get; set; }


    }
}
