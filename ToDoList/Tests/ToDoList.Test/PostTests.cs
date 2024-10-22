namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.WebApi.Controllers;
public class PostTests
{
    [Fact]
    public void Create_OneItem_ReturnsCreated()
    {
        // // Arrange
        // var controller = new ToDoItemsController();
        // var request = new ToDoItemCreateRequestDto("Test name", "Test description", false);

        // // Act
        // var result = controller.Create(request);
        // var createdResult = Assert.IsType<CreatedAtActionResult>(result);

        // // Assert
        // Assert.Equal(201, createdResult.StatusCode);
    }

}
