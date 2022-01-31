using DezvoltareaAplicatiilorWeb.Data;
using DezvoltareaAplicatiilorWeb.Models;
using DezvoltareaAplicatiilorWeb.Repositories.BrandRepository;
using DezvoltareaAplicatiilorWeb.Repositories.CategoryRepository;
using DezvoltareaAplicatiilorWeb.Repositories.MARepository;
using DezvoltareaAplicatiilorWeb.Repositories.OrderRepository;
using DezvoltareaAplicatiilorWeb.Repositories.ProductRepository;
using DezvoltareaAplicatiilorWeb.Repositories.ReviewRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DezvoltareaAplicatiilorWeb.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ApplicationDbContext db;
        
        public UnitOfWork(ApplicationDbContext _db)
        {
            db = _db;
            Movies = new MovieRepository(db);
            Genres = new GenreRepository(db);
            Actors = new ActorRepository(db);
            Directors = new DirectorRepository(db);
            Ratings = new RatingRepository(db);
            MAs = new MARepository(db);
        }

        public IMovieRepository Movies { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public IActorRepository Actors { get; private set; }
        public IDirectorRepository Directors { get; private set; }
        public IRatingRepository Ratings { get; private set; }
        public IMARepository MAs { get; private set; }


        public void Complete()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
