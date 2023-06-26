using Microsoft.VisualBasic;

namespace ExampleService_WebApi;

public class InMemoryDataProvider : InterfaceClass
{
    
    //creating inmemory data
    public List<TaskModel> tasks = new List<TaskModel>(){
        new TaskModel{TaskName = "Clone Repo", TaskDescription="Create a repo and clone it", TaskStatus="Completed",},
         new TaskModel{TaskName = "Commit your works", TaskDescription="Create a branch and commit your works in it", TaskStatus="Active",},
          new TaskModel{TaskName = "Raise PR", TaskDescription="Create a Pull request for merging it with main branch", TaskStatus="Not Started",}
    };

    //to add a new task in data
    public void AddNewTask(TaskModel task)
    {
        tasks.Add(task);
    }

    //to return all the task which already avail in data
    public List<TaskModel> ListofTask()
    {       
       return tasks;
    }
}
