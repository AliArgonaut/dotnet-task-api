namespace TaskManagementApi.Core.DTOs
{
    public class TodoTaskDto
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string? Description {get; set;} = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt {get; set;}
        public string Priority {get; set;} = string.Empty;
    }

    public class CreateTodoTaskDto
    {
        public string Title {get; set;} = string.Empty;
        public string? Description {get; set;}
        public string Priority {get; set;} = 'Med' //default medium 
    }

    public class UpdateTodoTaskDto
    {
        public string? Title {get; set;}
        public string? Description {get; set;} = string.Empty;
        public bool? IsCompleted {get; set;}
        public string? Priority {get; set;}
    }
}
