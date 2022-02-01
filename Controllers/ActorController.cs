using DezvoltareaAplicatiilorWeb.Models;
using DezvoltareaAplicatiilorWeb.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace DezvoltareaAplicatiilorWeb.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/actor")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public ActorController(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }

        [Authorize(Roles ="Administrator")]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("add")]
        public async Task<IActionResult> Add([Microsoft.AspNetCore.Mvc.FromBody]  Actor actor)
        {
            if (actor == null)
            {
                return BadRequest();
            }
            try
            {
                await Task.Run(() => unitOfWork.Actors.Add(actor));
                await Task.Run(() => unitOfWork.Complete());
            }
            catch 
            {
                return BadRequest();
            }

            return NoContent();
        }
        [Authorize(Roles = "Administrator")]
        [Microsoft.AspNetCore.Mvc.HttpDelete]
        [Microsoft.AspNetCore.Mvc.Route("delete/{id}")]
        public bool Delete(int id)
        {
            try
            {
                unitOfWork.Actors.Delete(id);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [Authorize(Roles = "Administrator")]
        [Microsoft.AspNetCore.Mvc.HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("update")]
        public bool Update([Microsoft.AspNetCore.Mvc.FromBody] Actor actor)
        {
            try
            {
                unitOfWork.Actors.Edit(actor);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        [Authorize(Roles = "Administrator")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("get/{id}")]
        public Object GetActor(int id)
        {
            var data = unitOfWork.Actors.GetActor(id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }


        [Authorize(Roles = "Administrator")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("getAll")]
        public Object Get()
        {
            var data = unitOfWork.Actors.Get();
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
