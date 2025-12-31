using Microsoft.AspNetCore.Mvc;
using TaskManagementApi.Core.DTOs;
using TaskManagementApi.Core.Interfaces;

namespace TaskManagementApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoTaskController : ControllerBase 
    {
        private readonly ITodoTaskService _taskService;
        private readonly ILogger<TodoTaskController> _logger;

        public TodoTaskController(ITodoTaskService taskService, ILogger<TodoTaskController> logger)
        {
            _taskService = taskService;
            _logger = logger
        }

        ///<summary>
        ///get all tasks
        ///</summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoTaskDto>>> GetAllTasks()
        {
            try 
            {
                var tasks = await _taskService.GetAllTasksAsync();
                return Ok(tasks)
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error retrieving tasks");
                return StatusCode(500, "an error occured when retrieving tasks")
            }
        }

        ///<summary>
        ///get a specific task by id
        ///</summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoTaskDto>> GetTaskById(int id)
        {
            try 
            {
                var task = await _taskService.GetTaskByIdAsync(id);
                if (task == null)
                {
                    return NotFound($"Task with id {id} not found")
                }
                return Ok(task)
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error retrieving task with id {TaskId}", id);
                return StatusCode(500, "an error occured when retrieving task with provided id");
            }
        }

        ///<summary>
        ///get completed tasks 
        ///</summary>
        [HttpGet("completed")]
        public async Task<ActionResult<IEnumerable<TodoTaskDto>>> GetCompletedTasks()
        {
            try
            {
                var tasks = await _taskService.GetCompletedTasksAsync();
                return Ok(tasks)
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error getting tasks by completed status")
                return StatusCode(500, "an error occured when getting tasks by completed status")
            }
        }

        ///<summary>
        ///get pending tasks 
        ///</summary>
        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<TodoTaskDto>>> GetPendingTasks()
        {
            try
            {
                var tasks = await _taskService.GetPendingTasksAsync();
                return Ok(tasks)
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error getting pending tasks");
                return StatusCode(500, "error getting pending tasks")
            }
        }

        ///<summary>
        ///create a task 
        ///</summary>
        [HttpPost]
        public async Task<ActionResult<TodoTaskDto>> CreateTask([FromBody] CreateTodoTaskDto createDto)
        {
            try 
            {
                var task = await _taskService.CreateTaskAsync(createDto);
                return CreatedAtAction(nameof(GetTaskById), new {id = task.Id}, task)
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error creating new task");
                return StatusCode(500, "Error creating new task')
            }
        }


        ///<summary>
        ///update a task 
        ///</summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<TodoTaskDto>> UpdateTask(int id, [FromBody] UpdateTodoTaskDto updateDto)
        {
            try 
            {
                var task = await _taskService.UpdateTaskAsync(id, updateDto);
                return Ok(task);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error updating task");
                return StatusCode(500, "error updating task")
            }
        }


        ///<summary>
        ///delete a task 
        ///</summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            try 
            {
                var task = await _taskService.DeleteTaskAsync(id);
                return Ok(task)
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error deleting task");
                return StatusCode(500, "error deleting task")
            }
        }
    }
}
