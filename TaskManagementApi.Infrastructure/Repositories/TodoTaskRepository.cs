using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Core.Interfaces;
using TaskManagementApi.Core.Models;
using TaskManagementApi.Infrastructure.Data;

namespace TaskManagementApi.Infrastructure.Repositories
{
    public class TodoTaskRepository : Repository<TodoTask>, ITodoTaskRepository
    {
        public TodoTaskRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TodoTask>> GetCompletedTasksAsync()
        {
            return await _dbSet
                .Where(t => t.IsCompleted)
                .OrderByDescending(t => t.CompletedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoTask>> GetPendingTasksAsync()
        {
            return await _dbSet
                .Where(t => !t.IsCompleted)
                .OrderByDescending(t => t.Priority)
                .ThenBy(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoTask>> GetTasksByPriorityAsync(Priority priority)
        {
            return await _dbSet
                .Where(t => t.Priority == priority)
                .OrderBy(t => t.CreatedAt)
                .ToListAsync();
        }
    }
}
