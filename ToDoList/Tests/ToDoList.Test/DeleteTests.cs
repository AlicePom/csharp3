namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.WebApi.Controllers;

public class DeleteTests
{
    [Fact]
    public void Delete_AllItems_ReturnsNoContent()
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
        ToDoItemsController.items.Add(toDoItem);

        // Act
        var result = controller.DeleteById(1);

        // Assert
        var resultNoContent = Assert.IsType<NoContentResult>(result);
        Assert.Equal(204, resultNoContent.StatusCode);
    }

    [Fact]
    public void Delete_AllItems_ReturnsNotFound()
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
        ToDoItemsController.items.Add(toDoItem);

        // Act
        var result = controller.DeleteById(2);

        // Assert
        var resultNotFound = Assert.IsType<NotFoundResult>(result);
        Assert.Equal(404, resultNotFound.StatusCode);
    }
}
