using DezvoltareaAplicatiilorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DezvoltareaAplicatiilorWeb.Repositories.MARepository
{
    public interface IMARepository
    {
        List<MA> Get();
        MA GetMA(int ida, int idm);

        public Task Add(MA ma);
        public Task Delete(int ida, int idm);
        public Task Edit(MA ma);
    }
}
