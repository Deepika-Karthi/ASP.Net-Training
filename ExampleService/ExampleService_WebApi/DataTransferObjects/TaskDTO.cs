namespace ExampleService_WebApi;

/// <summary>
/// DTO of Task Model
/// </summary>
public class TaskDTO
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
