using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class EntityController<T> : ControllerBase where T : Entity
    {
        private readonly IService<T> _service;

        protected EntityController(IService<T> service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.ReadAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _service.ReadAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T value)
        {
            var entity = await _service.CreateAsync(value);

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] T value)
        {
            var entity = await _service.ReadAsync(id);
            if (entity == null)
                return NotFound();
            await _service.UpdateAsync(id, value);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _service.ReadAsync(id);
            if (entity == null)
                return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
