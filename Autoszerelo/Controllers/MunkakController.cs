using Autoszerelo.DataClasses;
using Autoszerelo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Autoszerelo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MunkakController : ControllerBase
    {
        private readonly IMunkaService _munkaService;

        public MunkakController(IMunkaService munkaService)
        {
            _munkaService = munkaService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Munka munka)
        {
            var existingMunka = _munkaService.Get(munka.MunkaAzonosito);

            if (existingMunka is not null)
            {
                return Conflict();
            }

            _munkaService.Add(munka);
            return Ok();
        }

        [HttpGet("{ID:guid}")]
        public ActionResult<Munka> Get(Guid ID)
        {
            var munka = _munkaService.Get(ID);

            if (munka is null)
            {
                return NotFound();
            }

            return Ok(munka);
        }

        [HttpGet]
        public ActionResult<List<Munka>> GetAll()
        {
            return Ok(_munkaService.GetAll());
        }

        [HttpPut("{ID:guid}")]
        public IActionResult Update(Guid ID, [FromBody] Munka munka)
        {
            if (ID != munka.MunkaAzonosito)
            {
                return BadRequest();
            }

            var existingMunka = _munkaService.Get(ID);

            if (existingMunka is null)
            {
                return NotFound();
            }

            _munkaService.Update(munka);
            return Ok();
        }

        [HttpDelete("{ID:guid}")]
        public IActionResult Delete(Guid ID)
        {
            var munka = _munkaService.Get(ID);

            if (munka is null)
            {
                return NotFound();
            }

            _munkaService.Delete(ID);
            return Ok();
        }
    }
}
