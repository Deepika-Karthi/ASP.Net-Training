namespace ExampleService_WebApi;

/// <summary>
/// Properties related to Task logic
/// </summary>
public class TaskModel
{   
    /// <summary>
    /// Name of the task
    /// </summary>
    public string  TaskName{ get; set; }    

    /// <summary>
    /// Description about the task
    /// </summary>
    public string TaskDescription{ get; set;}

    /// <summary>
    /// Status detail about the task
    /// </summary>
    public string TaskStatus{ get; set;}

}