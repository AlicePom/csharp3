namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.WebApi.Controllers;
public class ReadByIdTests
{
    [Fact]
    public void ReadById_ValidId_ReturnsItem()
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
        var result = controller.ReadById(toDoItem.ToDoItemId);

        // Assert
        var resultOkObjectResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnsItems = Assert.IsType<ToDoItemGetResponseDto>(resultOkObjectResult.Value);

        Assert.Equal(toDoItem.ToDoItemId, returnsItems.ToDoItemId);
        Assert.Equal(toDoItem.Name, returnsItems.Name);
        Assert.Equal(toDoItem.Description, returnsItems.Description);
        Assert.Equal(toDoItem.IsCompleted, returnsItems.IsCompleted);
    }

    [Fact]
    public void ReadById_InvalidId_ReturnsNotFound()
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
        var invalidId = -1;
        var result = controller.ReadById(invalidId);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
}
