using DezvoltareaAplicatiilorWeb.Models;
using DezvoltareaAplicatiilorWeb.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DezvoltareaAplicatiilorWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public MovieController(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("add")]
        public async Task<Object> Add([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }
            try
            {
                await Task.Run(() => unitOfWork.Movies.Add(movie));
            }
            catch
            {
                return BadRequest();
            }

            return NoContent();
        }
        [Authorize(Roles = "User")]
        [HttpDelete]
        [Route("delete")]
        public bool Delete(int id)
        {
            try
            {
                unitOfWork.Movies.Delete(id);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [Authorize(Roles = "User")]
        [HttpPut]
        [Route("update")]
        public bool Update([FromBody] Movie movie)
        {
            try
            {
                unitOfWork.Movies.Edit(movie);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        [Route("get/{id}")]
        public Object GetMovie(int id)
        {
            var data = unitOfWork.Movies.GetMovie(id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        [Route("getAll")]
        public Object Get()
        {
            var data = unitOfWork.Movies.Get();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        [Route("getMovie")]
        public Object GetMovieDirector(int id)
        {
            var movies = unitOfWork.Movies.Get();
            var directors = unitOfWork.Directors.Get();
            var data = from m in movies
                                join d in directors on m.director_id equals d.id
                                select new
                               {
                                  MovieName = m.title,
                                  DirectorName = d.firstName + d.lastName
                               };

            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

       


    }
}
