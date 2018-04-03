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
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;

        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                
                _invoiceService.GetAll()
                );
        }
        
        // GET api/values/5s
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                 _invoiceService.Get(id)
                 );
        }
      
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Invoice model)
        {
            return Ok(
                _invoiceService.Add(model)
                );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Invoice model)
        {
            return Ok(
                _invoiceService.Update(model)
                );
        }

       
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _invoiceService.Delete(id)
                );
        }
    }
}
