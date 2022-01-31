using DezvoltareaAplicatiilorWeb.Data;
using DezvoltareaAplicatiilorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DezvoltareaAplicatiilorWeb.Repositories.OrderRepository
{
    public class ActorRepository : IActorRepository
    {
        protected readonly ApplicationDbContext db;

        public ActorRepository(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task Add(Actor actor)
        {
            var obj = await db.Actors.AddAsync(actor);
            await db.SaveChangesAsync();
            
        }

        public async Task Delete(int id)
        {
            Actor actor = db.Actors.Where(x => x.id == id).FirstOrDefault();
            db.Remove(actor);
            await db.SaveChangesAsync();
        }

        public async Task Edit(Actor actor)
        {
            db.Actors.Update(actor);
            await db.SaveChangesAsync();
        }

        public Actor GetActor(int id)
        {
            return db.Actors.Where(x => x.id == id).FirstOrDefault();
        }

        public List<Actor> Get()
        {
            return db.Actors.ToList();
        }
    }
}
