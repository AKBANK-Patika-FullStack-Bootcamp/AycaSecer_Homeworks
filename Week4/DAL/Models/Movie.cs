using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public string MovieOverview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double VoteAverage { get; set; }
        public int GenresId { get; set; }
    }
}
