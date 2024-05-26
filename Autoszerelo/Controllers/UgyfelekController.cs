using Autoszerelo.DataClasses;
using Autoszerelo.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Autoszerelo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UgyfelekController : ControllerBase
    {
        private readonly IUgyfelService _ugyfelService;

        public UgyfelekController(IUgyfelService ugyfelService)
        {
            _ugyfelService = ugyfelService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Ugyfel ugyfel)
        {
            var existingUgyfel = _ugyfelService.Get(ugyfel.Ugyfelszam).Result;

            if (existingUgyfel is not null)
            {
                return Conflict();
            }

            _ugyfelService.Add(ugyfel);
            return Ok();
        }

        [HttpGet("{ID:guid}")]
        public ActionResult<Ugyfel> Get(Guid ID)
        {
            var ugyfel = _ugyfelService.Get(ID).Result;

            if (ugyfel is null)
            {
                return NotFound();
            }

            return Ok(ugyfel);
        }

        [HttpGet("list")]
        public ActionResult<List<Ugyfel>> GetAll()
        {
            return Ok(_ugyfelService.GetAll().Result);
        }

        [HttpPut("{ID:guid}")]
        public IActionResult Update(Guid ID, [FromBody] Ugyfel ugyfel)
        {
            if (ID != ugyfel.Ugyfelszam)
            {
                return BadRequest();
            }

            var existingUgyfel = _ugyfelService.Get(ID).Result;

            if (existingUgyfel is null)
            {
                return NotFound();
            }

            _ugyfelService.Update(ugyfel);
            return Ok();
        }

        [HttpDelete("{ID:guid}")]
        public IActionResult Delete(Guid ID)
        {
            var ugyfel = _ugyfelService.Get(ID).Result;

            if (ugyfel is null)
            {
                return NotFound();
            }

            _ugyfelService.Delete(ID);
            return Ok();
        }
    }
}
