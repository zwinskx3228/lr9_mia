using Microsoft.AspNetCore.Mvc;
using lr4_3.Models;
using lr4_3.Services.Interfaces;

namespace lr4_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _service;

        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var item = await _service.GetByIdAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Restaurant restaurant)
        {
            await _service.CreateAsync(restaurant);
            return CreatedAtAction(nameof(Get), new { id = restaurant.Id }, restaurant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Restaurant restaurant)
        {
            restaurant.Id = id;
            var result = await _service.UpdateAsync(restaurant);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}