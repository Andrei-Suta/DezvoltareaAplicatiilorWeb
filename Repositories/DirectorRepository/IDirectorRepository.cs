using DezvoltareaAplicatiilorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DezvoltareaAplicatiilorWeb.Repositories.ProductRepository
{
    public interface IDirectorRepository
    {
        List<Director> Get();
        Director GetDirector(int id);

        public Task Add(Director director);
        public Task Delete(int id);
        public Task Edit(Director director);
    }
}
