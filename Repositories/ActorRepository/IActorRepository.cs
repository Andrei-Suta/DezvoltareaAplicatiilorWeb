using DezvoltareaAplicatiilorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DezvoltareaAplicatiilorWeb.Repositories.OrderRepository
{
    public interface IActorRepository
    {
        List<Actor> Get();
        Actor GetActor(int id);

        public Task Add(Actor actor);
        public Task Delete(int id);
        public Task Edit(Actor actor);
    }
}
