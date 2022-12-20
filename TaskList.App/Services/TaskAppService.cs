using TaskList.App.Entities;
using TaskList.App.Services.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TaskList.App.Services;

public class TaskAppService : ApplicationService, ITaskAppService
{
    private readonly IRepository<TodoTask, int> _repository;

    public TaskAppService(IRepository<TodoTask, int> repository)
    {
        _repository = repository;
    }

    public async Task<List<TodoTaskDto>> GetListAsync()
    {
        var items = await _repository.GetListAsync();
        return items.Select(item => new TodoTaskDto
        {
            Id = item.Id,
            Value = item.Value,
            CreationDate = item.CreationDate
        }).ToList();
    }

    public async Task<TodoTaskDto> CreateAsync(string value, string creationDate)
    {
        var item = await _repository.InsertAsync(new TodoTask
        {
            Value = value, CreationDate = creationDate
        });

        return new TodoTaskDto
        {
            Id = item.Id,
            Value = item.Value,
            CreationDate = item.CreationDate
        };
    }

    public async Task<TodoTaskDto> DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        var item = await _repository.FindAsync(id);
        return item != null
            ? new TodoTaskDto { Id = item.Id, Value = item.Value, CreationDate = item.CreationDate }
            : null;
    }

    public async Task<TodoTaskDto> UpdateAsync(TodoTaskDto input)
    {
        var task = await _repository.FindAsync(input.Id);
        if (task != null)
        {
            task.Value = input.Value;
            task = await _repository.UpdateAsync(task);
            return new TodoTaskDto
            {
                Id = task.Id, Value = task.Value, CreationDate = task.CreationDate
            };
        }

        return null;
    }
}