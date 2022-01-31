using DezvoltareaAplicatiilorWeb.Data;
using DezvoltareaAplicatiilorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DezvoltareaAplicatiilorWeb.Repositories.BrandRepository
{
    public class MovieRepository : IMovieRepository
    {
        protected readonly ApplicationDbContext db;

        public MovieRepository(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task Add(Movie movie)
        {
            await db.Movies.AddAsync(movie);
            await db.SaveChangesAsync();
            
        }

        public async Task Delete(int id)
        {
            Movie movie = db.Movies.Where(x => x.id == id).FirstOrDefault();
            db.Remove(movie);
            await db.SaveChangesAsync();
        }

        public async Task Edit(Movie movie)
        {
            db.Movies.Update(movie);
            await db.SaveChangesAsync();

        }

        public Movie GetMovie(int id)
        {
            return db.Movies.Where(x => x.id == id).FirstOrDefault();


        }

        public List<Movie> Get()
        {
            return db.Movies.ToList();
        }
    }
}
