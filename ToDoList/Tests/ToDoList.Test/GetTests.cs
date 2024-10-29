namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.WebApi.Controllers;

public class GetTests
{
    [Fact]
    public void Get_AllItems_ReturnsAllItems_ReturnsOk()
    {
        // Arrange
        var controller = new ToDoItemsController();
        var toDoItem = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Test name",
            Description = "Test description",
            IsCompleted = false
        };
        controller.items.Add(toDoItem);

        // Act
        var result = controller.Read();
        // var resultResult = result.Result;
        // var value = result.Value;

        // Assert
        var resultOkObjectResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnsItems = (resultOkObjectResult.Value as IEnumerable<ToDoItemGetResponseDto>).ToList();
        Assert.Single(returnsItems);
        Assert.Equal(toDoItem.Name, returnsItems[0].Name);
    }

    [Fact]
    public void Get_AllItems_ReturnsNotFound()
    {
        // Arrange
        var controller = new ToDoItemsController();

        // Act
        controller.items.Clear();
        var result = controller.Read();

        // Assert
        var resultNotFoundResult = Assert.IsType<NotFoundResult>(result.Result);
        Assert.Equal(404, resultNotFoundResult.StatusCode);
    }
}
