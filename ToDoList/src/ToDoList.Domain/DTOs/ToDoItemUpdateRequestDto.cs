namespace ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

public record ToDoItemUpdateRequestDto(string Name, string Description, bool IsCompleted)
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public ToDoItem ToDomain(int toDoItemId)
    {
        return new ToDoItem
        {
            ToDoItemId = toDoItemId,
            Name = this.Name,
            Description = this.Description,
            IsCompleted = this.IsCompleted,
        };
    }
}
