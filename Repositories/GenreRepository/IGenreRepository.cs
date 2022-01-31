using DezvoltareaAplicatiilorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DezvoltareaAplicatiilorWeb.Repositories.CategoryRepository
{
    public interface IGenreRepository
    {
        List<Genre> Get();
        Genre GetGenre(int id);

        public Task Add(Genre genre);
        public Task Delete(int id);
        public Task Edit(Genre genre);
    }
}
