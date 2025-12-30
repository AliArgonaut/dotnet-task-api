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
                .OrderByDescending(t => t.CoompletedAt)
                .ToListAsync();
        }


    }
}
