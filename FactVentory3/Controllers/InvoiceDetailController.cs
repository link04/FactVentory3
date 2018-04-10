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
    public class InvoiceDetailController : Controller
    {
        private readonly IInvoiceDetailService _invoiceDetailService;

        public InvoiceDetailController(IInvoiceDetailService invoiceDetailService)
        {
            _invoiceDetailService = invoiceDetailService;

        }

        // GET api/values
       [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _invoiceDetailService.GetAll()
                );
        }

        // GET api/values/5s
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                 _invoiceDetailService.Get(id)
                 );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] InvoiceDetail model)
        {
            return Ok(
                _invoiceDetailService.Add(model)
                );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]int id)
        {
            return Ok(
                _invoiceDetailService.Update(id)
                );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _invoiceDetailService.Delete(id)
                );
        }
    }
}
