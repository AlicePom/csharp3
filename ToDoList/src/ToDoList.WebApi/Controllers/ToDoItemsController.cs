namespace ToDoList.WebApi.Controllers;

using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController : ControllerBase
{
    public static readonly List<ToDoItem> items = [];

    [HttpPost]
    public IActionResult Create(ToDoItemCreateRequestDto request)
    {
        //map to Domain object as soon as possible
        var item = request.ToDomain();

        //try to create an item
        try
        {
            item.ToDoItemId = items.Count == 0 ? 1 : items.Max(o => o.ToDoItemId) + 1;
            items.Add(item);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        //respond to client
        return Created(); //201
    }

    [HttpGet]
    public ActionResult<IEnumerable<ToDoItemGetResponseDto>> Read()
    {
        List<ToDoItemGetResponseDto> allToDoItemsList = new List<ToDoItemGetResponseDto>();

        try
        {
            if (items == null || items.Count == 0)
            {
                return NotFound(); //404
            }

            foreach (var item in items)
            {
                allToDoItemsList.Add(ToDoItemGetResponseDto.FromDomain(item));
            }

        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }

        return Ok(allToDoItemsList); //200
    }

    [HttpGet("{toDoItemId:int}")]
    public IActionResult ReadById(int toDoItemId)
    {
        var item = items.Find(i => i.ToDoItemId == toDoItemId);
        try
        {
            if (item == null)
            {
                return NotFound(); //404
            }

            return Ok(ToDoItemGetResponseDto.FromDomain(item));
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("{toDoItemId:int}")]
    public IActionResult UpdateById(int toDoItemId, [FromBody] ToDoItemUpdateRequestDto request)
    {
        var indexOfOldInstance = items.FindIndex(i => i.ToDoItemId == toDoItemId);

        try
        {
            if (items == null)
            {
                return NotFound(); //404
            }
            var updatedItem = request.ToDomain(toDoItemId);
            items[indexOfOldInstance] = updatedItem;

            return NoContent(); // 204
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("{toDoItemId:int}")]
    public IActionResult DeleteById(int toDoItemId)
    {
        var item = items.Find(i => i.ToDoItemId == toDoItemId);

        try
        {
            if (item == null)
            {
                return NotFound(); //404
            }

            items.Remove(item);
            return NoContent(); // 204
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }
    }
}
