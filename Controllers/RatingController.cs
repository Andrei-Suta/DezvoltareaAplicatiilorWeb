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
    [Route("api/rating")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public RatingController(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] Rating rating)
        {
            if (rating == null)
            {
                return BadRequest();
            }
            try
            {
                await Task.Run(() => unitOfWork.Ratings.Add(rating));
                await Task.Run(() => unitOfWork.Complete());
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
                unitOfWork.Ratings.Delete(id);
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
        public bool Update([FromBody] Rating rating)
        {
            try
            {
                unitOfWork.Ratings.Edit(rating);
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
        public Object GetRating(int id)
        {
            var data = unitOfWork.Ratings.GetRating(id);
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
            var data = unitOfWork.Ratings.Get();
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
