using TaskManagementApi.Core.DTOs;
namespace TaskManagementApi.Core.Interfaces
{
    public interface ITodoTaskService
    {
        Task<IEnumerable<TodoTaskDto>> GetAllTasksAsync();
        Task<TodoTaskDto?> GetTaskById(int id);
        Task<TodoTaskDto> CreateTaskAsync(CreateTodoTaskDto createDto);
        Task<TodoTaskDto> UpdateTaskAsync(int id, UpdateTodoTaskDto updateDto);
        Task DeleteTaskAsync(int id);
        Task<IEnumerable<TodoTaskDto>> GetCompletedTasksAsync();
        Task<IEnumerable<TodoTaskDto>> GetPendingTasksAsync();
    }
}
