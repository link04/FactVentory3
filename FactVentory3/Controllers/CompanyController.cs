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
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;

        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _companyService.GetAll()
                );
        }

        // GET api/values/5s
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                 _companyService.Get(id)
                 );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Company model)
        {
            return Ok(
                _companyService.Add(model)
                );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Company model)
        {
            return Ok(
                _companyService.Update(model)
                );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _companyService.Delete(id)
                );
        }
    }
}
