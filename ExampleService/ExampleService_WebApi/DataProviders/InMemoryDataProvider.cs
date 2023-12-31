using Microsoft.VisualBasic;

namespace ExampleService_WebApi;

public class InMemoryDataProvider : IDataProvider
{
    
    /// <summary>
    /// adding some inmemory data
    /// </summary>

    public List<TaskModel> tasks = new(){
        new TaskModel{TaskName = "Clone Repo", TaskDescription="Create a repo and clone it", TaskStatus="Completed",},
        new TaskModel{TaskName = "Commit your works", TaskDescription="Create a branch and commit your works in it", TaskStatus="Active",},
        new TaskModel{TaskName = "Raise PR", TaskDescription="Create a Pull request for merging it with main branch", TaskStatus="Not Started",}
    };

   /// <summary>
   ///adding new task
   /// </summary>
   /// <param name="task">Task model to be added</param>

    public void AddNewTask(TaskModel task)
    {
        tasks.Add(task);
    }

    /// <summary>
    /// to return list of task available
    /// </summary>
    /// <returns>Task available in memmory</returns>
    
    public List<TaskModel> ListofTask()
    {       
       return tasks;
    }
}
