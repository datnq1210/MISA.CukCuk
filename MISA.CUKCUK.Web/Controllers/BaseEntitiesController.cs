using Microsoft.AspNetCore.Mvc;
using MISA.AppliactionCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CUKCUK.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntitiesController<T> : ControllerBase
    {
        IBaseService<T> _baseService;
        public BaseEntitiesController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_baseService.GetData());
        }

        // POST api/<BaseEntitiesController>
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {   
            return Ok(_baseService.Insert(entity));
        }

        // PUT api/<BaseEntitiesController>/5
        [HttpPut]
        public IActionResult Put([FromBody] T entity)
        {
            return Ok(_baseService.Update(entity));
        }

        // DELETE api/<BaseEntitiesController>/5
        [HttpDelete()]
        public IActionResult Delete(T Entity)
        {
            return Ok(_baseService.Delete(Entity));
        }
    }
}
