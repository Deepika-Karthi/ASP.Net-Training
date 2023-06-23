using Microsoft.VisualBasic;

namespace ExampleService_WebApi;

public class InMemoryDataProvider : InterfaceClass
{
    public List<TaskModel> tasks = new List<TaskModel>(){
        new TaskModel{TaskName = "Clone Repo", TaskDescription="Create a repo and clone it", TaskStatus="Completed",},
         new TaskModel{TaskName = "Commit your works", TaskDescription="Create a branch and commit your works in it", TaskStatus="Active",},
          new TaskModel{TaskName = "Raise PR", TaskDescription="Create a Pull request for merging it with main branch", TaskStatus="Not Started",}
    };

    
    public void AddNewTask(TaskModel task)
    {
        tasks.Add(task);
    }

    public List<TaskModel> ListofTask()
    {
       
       return tasks;
    }
}
