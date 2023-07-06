using Moq;
using Todo.TaskService.Core.Models;
using Todo.TaskService.Core.Ports;

namespace Todo.UnitTesting.ClassFixture
{
    /// <summary>
    /// Setting up class fixture for task controller 
    /// </summary>

    public class TaskInterfaceMock : IDisposable
    {
        #region PROPERTIES
        public Mock<ITaskService> interfaceClassWithData { get; }
        public Mock<ITaskService> interfaceClassWithoutData { get; } 

        #endregion

        #region CONSTRUCTOR
        public TaskInterfaceMock()
        {

            interfaceClassWithData = new Mock<ITaskService>();
            interfaceClassWithData
                .Setup(m => m.ListofTask())
                .Returns(new List<TaskModel>() {
                        new TaskModel{TaskName = "Clone Repo", TaskDescription="Create a repo and clone it", TaskStatus="Completed",},
                        new TaskModel{TaskName = "Commit your works", TaskDescription="Create a branch and commit your works in it", TaskStatus="Active",},
                        new TaskModel { TaskName = "Raise PR", TaskDescription = "Create a Pull request for merging it with main branch", TaskStatus = "Not Started", } }
                );


            interfaceClassWithoutData = new Mock<ITaskService>();
            interfaceClassWithoutData
                .Setup(m => m.ListofTask())
                .Returns(new List<TaskModel>());
        }

        #endregion

        #region DISPOSE LOGIC
        public void Dispose()
        {
            
        }
        #endregion
    }
}
