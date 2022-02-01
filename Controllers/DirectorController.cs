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
    [Route("api/director")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public DirectorController(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] Director director)
        {
            if (director == null)
            {
                return BadRequest();
            }
            try
            {
                await Task.Run(() => unitOfWork.Directors.Add(director));
                await Task.Run(() => unitOfWork.Complete());
            }
            catch
            {
                return BadRequest();
            }

            return NoContent();
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpDelete]
        [Route("delete")]
        public bool Delete(int id)
        {
            try
            {
                unitOfWork.Directors.Delete(id);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        [Route("update")]
        public bool Update([FromBody] Director director)
        {
            try
            {
                unitOfWork.Directors.Edit(director);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("get/{id}")]
        public Object GetDirector(int id)
        {
            var data = unitOfWork.Directors.GetDirector(id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }


        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("getAll")]
        public Object Get()
        {
            var data = unitOfWork.Directors.Get();
            var queryLastNames =
                from director in data
                group director by director.lastName[0];
                   
            var json = JsonConvert.SerializeObject(queryLastNames, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}
