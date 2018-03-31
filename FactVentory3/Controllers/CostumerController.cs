using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;


namespace FactVentory3.Controllers
{
  [Route("[controller]")]
    public class CostumerController : Controller
    {
        private readonly ICostumerService _costumerService;

        public CostumerController(ICostumerService costumerService)
        {
            _costumerService = costumerService;

        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _costumerService.GetAll()
                );
        }

        // GET api/values/5s
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                 _costumerService.Get(id)
                 );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Costumer model)
        {
            return Ok(
                _costumerService.Add(model)
                );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Costumer model)
        {
            return Ok(
                _costumerService.Update(model)
                );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _costumerService.Delete(id)
                );
        }
    }
}
