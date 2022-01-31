using DezvoltareaAplicatiilorWeb.Data;
using DezvoltareaAplicatiilorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DezvoltareaAplicatiilorWeb.Repositories.MARepository
{
    public class MARepository : IMARepository
    {
        protected readonly ApplicationDbContext db;

        public MARepository(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task Add(MA ma)
        {
            await db.MovieActor.AddAsync(ma);
            await db.SaveChangesAsync();

        }

        public async Task Delete(int ida, int idm )
        {
            MA ma = db.MovieActor.Where(x => x.idActor == ida && x.idMovie == idm).FirstOrDefault();
            db.Remove(ma);
            await db.SaveChangesAsync();
        }


        public async Task Edit(MA ma)
        {
            db.MovieActor.Update(ma);
            await db.SaveChangesAsync();

        }

        public MA GetMA(int ida, int idm)
        {
            return db.MovieActor.Where(x => x.idActor == ida && x.idMovie == idm).FirstOrDefault();


        }

        public List<MA> Get()
        {
            return db.MovieActor.ToList();
        }

     
    }
}
