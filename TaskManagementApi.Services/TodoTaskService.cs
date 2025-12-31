using TaskManagementApi.Core.DTOs;
using TaskManagementApi.Core.Interfaces;
using TaskManagementApi.Core.Models;

namespace TaskManagementApi.Services
{
    public class TodoTaskService : ITodoTaskService
    {
        private readonly ITodoTaskRepository _repository;

        public TodoTaskService(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TodoTaskDto>> GetAllTasksAsync()
        {
            var tasks = await _repository.GetAllAsync();
            return tasks.Select(MapToDto);
        }

        public async Task<TodoTaskDto?> GetTaskByIdAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            return task != null ? MapToDto(Task) : null;
        }

        public async Task<TodoTaskDto> CreateTaskAsync(CreateTodoTaskDto createDto)
        {
            var task = new TodoTask 
            {
                Title = createDto.Title,
                Description = createDto.Description,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow,
                Priority = Enum.Parse<Priority>(createDto.Priority)
            }

            var createdTask = await _repository.AddAsync(task);
            return MapToDto(createdTask);
        }

        public async Task<TodoTaskDto> UpdateTaskAsync(int id, UpdateTodoTaskDto updateDto)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null)
            {
                throw new KeyNotFoundException($"task with ID {id} not found");
            }

            if (!string.IsNullOrEmpty(updateDto.Title)) 
            {
                task.Title = updateDto.Title;
            }

            if (updateDto.Description != null)
            {
                task.Description = updateDto.Description;
            }

            if (updateDto.IsCompleted.HasValue && updateDto.IsCompleted.Value && !task.IsCompleted)
            {
                task.IsCompleted = true;
                task.CompletedAt = DateTime.UtcNow;
            }

            if (updateDto.IsCompleted.HasValue && !updateDto.IsCompleted.Value)
            {
                task.IsCompleted = false;
                task.CompletedAt = null;
            }

            if (!string.IsNullOrEmpty(updateDto.Priority))
            {
                task.Priority = Enum.Parse<Priority>(updateDto.Priority);
            }

            await _repository.UpdateAsync(task);
            return MapToDto(task);
        }

        public async Task DeleteTaskAsync(int id)
        {
            var exists = await _repository.ExistsAsync(id);
            if (!exists)
            {
                throw new KeyNotFoundException($"Task with id {id} not found");
            }

            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TodoTaskDto>> GetCompletedTasksAsync()
        {
            var tasks = await _repository.GetCompletedTasksAsync();
            return tasks.Select(MapToDto);
        }

        public async Task<IEnumerable<TodoTaskDto>> GetPendingTasksAsync()
        {
            var allTasks = await _repository.GetPendingTasksAsync();
            return tasks.Select(MapToDto);
        }
        private static TodoTaskDto MapToDto(TodoTask task)
        {
            return new TodoTaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                CreatedAt = task.CreatedAt,
                CompletedAt = task.CompletedAt,
                Priority = task.Priority.ToString();
            };
        }
    }
}
