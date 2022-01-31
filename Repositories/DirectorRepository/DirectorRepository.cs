using DezvoltareaAplicatiilorWeb.Data;
using DezvoltareaAplicatiilorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DezvoltareaAplicatiilorWeb.Repositories.ProductRepository
{
    public class DirectorRepository : IDirectorRepository
    {
        protected readonly ApplicationDbContext db;

        public DirectorRepository(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task Add(Director  director)
        {
            var obj = await db.Directors.AddAsync(director);
            await db.SaveChangesAsync();
            
        }

        public async Task Delete(int id)
        {
            Director director = db.Directors.Where(x => x.id == id).FirstOrDefault();
            db.Remove(director);
            await db.SaveChangesAsync();
        }

        public async Task Edit(Director director)
        {
            db.Directors.Update(director);
            await  db.SaveChangesAsync();
        }

        public Director GetDirector(int id)
        {
            return db.Directors.Where(x => x.id == id).FirstOrDefault();
        }

        public List<Director> Get()
        {
            return db.Directors.ToList();
        }
    }
}
