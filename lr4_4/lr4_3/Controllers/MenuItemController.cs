using Microsoft.AspNetCore.Mvc;
using lr4_3.Models;
using lr4_3.Services.Interfaces;

namespace lr4_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _service;

        public MenuItemController(IMenuItemService service)
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
        public async Task<IActionResult> Create(MenuItem menuItem)
        {
            await _service.CreateAsync(menuItem);
            return CreatedAtAction(nameof(Get), new { id = menuItem.Id }, menuItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, MenuItem menuItem)
        {
            menuItem.Id = id;
            var result = await _service.UpdateAsync(menuItem);
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
