using Volo.Abp.Domain.Entities;

namespace TaskList.App.Entities;

public class TodoTask: BasicAggregateRoot<int>
{
    public string Value { get; set; }
    public string CreationDate { get; set; }
}