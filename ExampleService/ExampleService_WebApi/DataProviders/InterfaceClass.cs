namespace ExampleService_WebApi;

//setting up the interfaces for loose coupling
public interface InterfaceClass
{
    List<TaskModel> ListofTask();
    void AddNewTask(TaskModel task);
}
