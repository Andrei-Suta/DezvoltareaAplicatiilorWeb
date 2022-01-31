using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DezvoltareaAplicatiilorWeb.Models
{
    public class Rating
    {
        public int id { get; set; }
        public string text { get; set; }
        public string name { get; set; }

        public int movie_id { get; set; }
    }
}
