using Todo.TaskService.Core.Models;

namespace Todo.TaskService.Core.Ports;

/// <summary>
/// Interface class for loose coupling
/// </summary>

public interface ITaskService
{

    /// <summary>
    /// returns the list of task
    /// </summary>
    /// <returns>task which are already added</returns>
    List<TaskModel> ListofTask();

    /// <summary>
    /// add a new task
    /// </summary>
    /// <param name="task">request for task model</param>
    void AddNewTask(TaskModel task);
}
