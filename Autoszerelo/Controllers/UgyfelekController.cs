using Autoszerelo.DataClasses;
using Autoszerelo.Services;
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
            var existingUgyfel = _ugyfelService.Get(ugyfel.Ugyfelszam);

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
            var ugyfel = _ugyfelService.Get(ID);

            if (ugyfel is null)
            {
                return NotFound();
            }

            return Ok(ugyfel);
        }

        [HttpGet]
        public ActionResult<List<Ugyfel>> GetAll()
        {
            return Ok(_ugyfelService.GetAll());
        }

        [HttpPut("{ID:guid}")]
        public IActionResult Update(Guid ID, [FromBody] Ugyfel ugyfel)
        {
            if (ID != ugyfel.Ugyfelszam)
            {
                return BadRequest();
            }

            var existingUgyfel = _ugyfelService.Get(ID);

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
            var ugyfel = _ugyfelService.Get(ID);

            if (ugyfel is null)
            {
                return NotFound();
            }

            _ugyfelService.Delete(ID);
            return Ok();
        }
    }
}
