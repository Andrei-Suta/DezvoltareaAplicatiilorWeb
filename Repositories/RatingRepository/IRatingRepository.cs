using DezvoltareaAplicatiilorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DezvoltareaAplicatiilorWeb.Repositories.ReviewRepository
{
    public interface IRatingRepository
    {
        List<Rating> Get();
        Rating GetRating(int id);

        public Task Add(Rating rating);
        public Task Delete(int id);
        public Task Edit(Rating rating);
    }
}
