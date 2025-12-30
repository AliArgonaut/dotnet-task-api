namespace TaskManagementApi.Core.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedtedAt {get; set;}
        public DateTime? CompletedAt {get; set;}
        public Priority Priority {get; set;}
    }

    public enum Priority
    {
        Low = 0,
        Med = 1,
        High = 2,
        Urgent = 3
    }
}
