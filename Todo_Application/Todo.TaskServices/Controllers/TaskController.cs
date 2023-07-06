using Todo_TaskService.CoreLayer.CustomFilters;
using Microsoft.AspNetCore.Mvc;
using Todo.TaskService.Core.Models;
using Todo.TaskService.Core.Ports;

namespace Todo_TaskService.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    #region PROPERTIES
    private readonly ITaskService _interface;
    private readonly TaskModelValidation _validationRequest;

    #endregion

    #region CONSTRUCTOR
    public TaskController(ITaskService interfaceClass, TaskModelValidation _requestValidation)
    {
        _interface = interfaceClass;
        _validationRequest = _requestValidation;
    }

    #endregion

    #region CRUD LOGICS

    /// <summary>
    /// to get the list of task
    /// </summary>
    /// <returns>List of task avail in memory</returns>
    /// 

    [HttpGet("List of your Task")]
    public IActionResult Get()
    {
        try
        {
            List<TaskModel> taskList = _interface.ListofTask();

            if (taskList == null || taskList.ToList().Count == 0)
            {
                return NotFound("No Task Found");
            }

            List<TaskDTO> outputTaskDTO = new List<TaskDTO>();
            foreach (var tasks in taskList)
            {
                var temp = new TaskDTO();
                temp.TaskDescription = tasks.TaskDescription;
                temp.TaskName = tasks.TaskName;
                temp.TaskStatus = tasks.TaskStatus;
                outputTaskDTO.Add(temp);
            }

            return Ok(outputTaskDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// To add a new task
    /// </summary>
    /// <param name="task">Ojects to be added</param>
    /// <returns>Success message of adding task</returns>
    /// 

    [HttpPost("Create your Task here")]
    public IActionResult Post([FromBody] TaskDTO taskRequest)
    {
        try
        {
            string validationResult = _validationRequest.ValidationLogic(taskRequest);

            if (validationResult != "ValidState")
            {
                return BadRequest(validationResult);
            }

            var taskModel = new TaskModel();

            taskModel.TaskStatus = taskRequest.TaskStatus;
            taskModel.TaskName = taskRequest.TaskName;
            taskModel.TaskDescription = taskRequest.TaskDescription;

            _interface.AddNewTask(taskModel);

            return Ok("Task added successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion
}