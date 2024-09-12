using Microsoft.AspNetCore.Mvc;
using MongoDBCrudExample.Models;
using MongoDBCrudExample.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly IItemRepository _itemRepository;

    public ItemsController(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Item>>> GetAllItems()
    {
        var items = await _itemRepository.GetAllItemsAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetItem(string id)
    {
        var item = await _itemRepository.GetItemByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult> CreateItem(Item item)
    {
        await _itemRepository.CreateItemAsync(item);
        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateItem(string id, Item item)
    {
        var existingItem = await _itemRepository.GetItemByIdAsync(id);
        if (existingItem == null) return NotFound();
        item.Id = id;
        await _itemRepository.UpdateItemAsync(id, item);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteItem(string id)
    {
        var existingItem = await _itemRepository.GetItemByIdAsync(id);
        if (existingItem == null) return NotFound();
        await _itemRepository.DeleteItemAsync(id);
        return NoContent();
    }
}
