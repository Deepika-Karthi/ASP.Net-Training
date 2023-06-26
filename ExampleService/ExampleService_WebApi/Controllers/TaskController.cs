using Microsoft.AspNetCore.Mvc;

namespace ExampleService_WebApi;

[ApiController]
[Route("[controller]")]
public class TaskController :  ControllerBase
{   
    private readonly ITaskInterface _interface;
    public TaskController(ITaskInterface interfaceClass)
    {
        _interface= interfaceClass;
    }
    
    /// <summary>
    /// to get the list of task
    /// </summary>
    /// <returns>List of task avail in memory</returns>
    [HttpGet("List of your Task")]
    public IActionResult Get()
    {   
        var taskList = _interface.ListofTask();
        
        List<TaskDTO> outputTaskDTO = new List<TaskDTO>();    
        foreach(var tasks in taskList)
        {
            var temp = new TaskDTO();
            temp.TaskDescription = tasks.TaskDescription;
            temp.TaskName = tasks.TaskName;
            temp.TaskStatus = tasks.TaskStatus;
            outputTaskDTO.Add(temp);  
        } 
    
        return Ok(outputTaskDTO);
    }

   /// <summary>
   /// To add a new task
   /// </summary>
   /// <param name="task">Ojects to be added</param>
   /// <returns>Success message of adding task</returns>
    [HttpPost("Create your Task here")]
    public IActionResult Post([FromBody] TaskDTO taskRequest)
    {         
        var taskModel = new TaskModel();

        taskModel.TaskStatus = taskRequest.TaskStatus;
        taskModel.TaskName = taskRequest.TaskName;
        taskModel.TaskDescription = taskRequest.TaskDescription;

        _interface.AddNewTask(taskModel);
                
        return Ok("Task added successfully");
    }

}
