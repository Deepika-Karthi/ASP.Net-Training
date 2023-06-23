using Microsoft.AspNetCore.Mvc;

namespace ExampleService_WebApi;

[ApiController]
[Route("[controller]")]
public class TaskController :  ControllerBase
{   
    private readonly InterfaceClass _interface;
    public TaskController(InterfaceClass interfaceClass)
    {
        _interface= interfaceClass;
    }

    [HttpGet("List of your Task")]
    public IActionResult Get()
    {   
        var TaskList = _interface.ListofTask();
        return Ok(TaskList);
    }

    [HttpPost("Create your Task here")]
    public IActionResult Post([FromBody] TaskDTO task)
    {
        var taskMapping = new TaskModel();
        taskMapping.TaskStatus = task.TaskStatus;
            taskMapping.TaskName = task.TaskName;
                taskMapping.TaskDescription = task.TaskDescription;

        _interface.AddNewTask(taskMapping);
                
        return Ok();
    }

}
