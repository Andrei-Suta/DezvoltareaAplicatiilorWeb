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
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public GenreController(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }

        [Authorize(Roles="User")]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] Genre genre)
        {
            if (genre == null)
            {
                return BadRequest();
            }
            try
            {
                await Task.Run(() => unitOfWork.Genres.Add(genre));
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
                unitOfWork.Genres.Delete(id);
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
        public bool Update([FromBody] Genre genre)
        {
            try
            {
                unitOfWork.Genres.Edit(genre);
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
        public Object GetGenre(int id)
        {
            var data = unitOfWork.Genres.GetGenre(id);
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
            var data = unitOfWork.Genres.Get();
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
