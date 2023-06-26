namespace ExampleService_WebApi;

//DTO class to avoid exposing Model class
public class TaskDTO
{
    public string  TaskName{ get; set; }    
    public string TaskDescription{ get; set;}

    public string TaskStatus{ get; set;}
}
