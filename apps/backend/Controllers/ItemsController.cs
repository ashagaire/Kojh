using backend.Services;
using Deraa.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _itemService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _itemService.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Apartment item) => Ok(await _itemService.CreateAsync(item));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Apartment item)
        {
            var updatedItem = await _itemService.UpdateAsync(id, item);
            return updatedItem == null ? NotFound() : Ok(updatedItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            await _itemService.DeleteAsync(id) ? Ok() : NotFound();
    }
}
