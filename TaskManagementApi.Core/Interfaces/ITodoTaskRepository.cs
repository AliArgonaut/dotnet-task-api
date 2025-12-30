using TaskManagementApi.Core.Models;

namespace TaskManagementApi.Core.Interfaces
{
    public interface ITodoTaskRepository : IRepository<TodoTask>
    {
        Task<IEnumerable<TodoTask>> GetCompletedTasksAsync();
        Task<IEnumerable<TodoTask>> GetPendingTasksAsync();
        Task<IEnumerable<TodoTask>> GetTasksByPriority(Priority priority);
    }
}
