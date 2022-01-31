using DezvoltareaAplicatiilorWeb.Data;
using DezvoltareaAplicatiilorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DezvoltareaAplicatiilorWeb.Repositories.ReviewRepository
{
    public class RatingRepository : IRatingRepository
    {
        protected readonly ApplicationDbContext db;

        public RatingRepository(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task Add(Rating  rating)
        {
            var obj = await db.Ratings.AddAsync(rating);
            await db.SaveChangesAsync();
        }

        public async Task  Delete(int id)
        {
            Rating rating = db.Ratings.Where(x => x.id == id).FirstOrDefault();
            db.Remove(rating);
            await db.SaveChangesAsync();
        }

        public async Task Edit(Rating rating)
        {
            db.Ratings.Update(rating);
            await db.SaveChangesAsync();
        }

        public Rating GetRating(int id)
        {
            return db.Ratings.Where(x => x.id == id).FirstOrDefault();
        }

        public List<Rating> Get()
        {
            return db.Ratings.ToList();
        }
    }
}
