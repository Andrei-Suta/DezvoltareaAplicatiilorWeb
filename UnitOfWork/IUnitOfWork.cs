using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DezvoltareaAplicatiilorWeb.Repositories;
using DezvoltareaAplicatiilorWeb.Repositories.CategoryRepository;
using DezvoltareaAplicatiilorWeb.Repositories.OrderRepository;
using DezvoltareaAplicatiilorWeb.Repositories.ProductRepository;
using DezvoltareaAplicatiilorWeb.Repositories.ReviewRepository;
using DezvoltareaAplicatiilorWeb.Repositories.BrandRepository;
using DezvoltareaAplicatiilorWeb.Repositories.MARepository;

namespace DezvoltareaAplicatiilorWeb.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository Movies { get;  }
        IGenreRepository Genres { get; }
        IActorRepository Actors { get; }
        IDirectorRepository Directors { get; }
        IRatingRepository Ratings { get; }
        IMARepository MAs { get; }

        public void Complete();
    }
}
