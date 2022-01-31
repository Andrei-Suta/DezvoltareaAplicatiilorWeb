using DezvoltareaAplicatiilorWeb.Data;
using DezvoltareaAplicatiilorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DezvoltareaAplicatiilorWeb.Repositories.CategoryRepository
{
    public class GenreRepository : IGenreRepository
    {
        protected readonly ApplicationDbContext db;

        public GenreRepository(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task Add(Genre genre)
        {
            var obj = await db.Genres.AddAsync(genre);
            await db.SaveChangesAsync();
            
        }

        public async Task Delete(int id)
        {
            Genre genre = db.Genres.Where(x => x.id == id).FirstOrDefault();
            db.Remove(genre);
            await db.SaveChangesAsync();
        }

        public async Task Edit(Genre genre)
        {
            db.Genres.Update(genre);
            await db.SaveChangesAsync();
        }

        public Genre GetGenre(int id)
        {
            return db.Genres.Where(x => x.id == id).FirstOrDefault();
        }

        public List<Genre> Get()
        {
            return db.Genres.ToList();
        }
    }
}
