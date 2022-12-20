using Volo.Abp.Application.Dtos;

namespace TaskList.App.Services.Dtos;

public class TodoTaskDto
{
    public int Id { get; set; }
    public string Value { get; set; }
    public string CreationDate { get; set; }
}