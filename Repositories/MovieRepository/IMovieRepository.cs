using DezvoltareaAplicatiilorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DezvoltareaAplicatiilorWeb.Repositories.BrandRepository
{
    public interface IMovieRepository
    {
        List<Movie> Get();
        Movie GetMovie(int id);

        public Task Add(Movie movie);
        public Task Delete(int id);
        public Task Edit(Movie movie);
    }
}
