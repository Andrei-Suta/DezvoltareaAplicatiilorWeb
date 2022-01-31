using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DezvoltareaAplicatiilorWeb.Models
{
    public class Movie
    {
        public int id { get; set; }
        public int director_id { get; set; }
        public int genre_id { get; set; }
        public string title { get; set; }
        public int rating { get; set; }
        public int year { get; set; }

    }
}
