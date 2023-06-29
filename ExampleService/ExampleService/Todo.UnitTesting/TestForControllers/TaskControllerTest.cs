using ExampleService_WebApi;
using Microsoft.AspNetCore.Mvc;
using Todo.UnitTesting.ClassFixture;

namespace Todo.UnitTesting.TestForControllers
{
    public class TaskControllerTest : IClassFixture<TaskInterfaceMock>
    {
        #region PROPERTIES

        private readonly TaskInterfaceMock _fixture;

        TaskDTO DummyDataForPostAPI = new TaskDTO { TaskDescription = "Checking for post test", TaskName = "Check Post API", TaskStatus = "Started" };

        #endregion

        #region CONSTRUCTOR
        public TaskControllerTest(TaskInterfaceMock taskInterface)
        {
            _fixture = taskInterface;
        }

        #endregion

        #region TEST LOGICS

        /// <summary>
        /// test for get API when the data is sent correctly
        /// </summary>

        [Fact]
        public void Get_WhenDataFound_ReturnOkResponse()
        {

            var taskController = new TaskController(_fixture.interfaceClassWithData.Object);


            var result = taskController.Get();


            Assert.IsType<OkObjectResult>(result);

        }

        /// <summary>
        /// test for get API when there is no data to return
        /// </summary>

        [Fact]
        public void Get_WhenDataNotFound_ReturnNotFoundResponse()
        {

            var taskController = new TaskController(_fixture.interfaceClassWithoutData.Object);


            var result = taskController.Get();


            Assert.IsType<NotFoundObjectResult>(result);

        }

        /// <summary>
        /// test for post API when correct data is given
        /// </summary>

        [Fact]
        public void Post_WhenDataIsGiven_NeedToAdd()
        {


            var taskController = new TaskController(_fixture.interfaceClassWithData.Object);


            var result = taskController.Post(DummyDataForPostAPI);


            Assert.IsType<OkObjectResult>(result);

        }

        /// <summary>
        /// test for post API when input is null
        /// </summary>

        [Fact]
        public void Post_WhenNullDataIsGiven_NeedToThrowBadResponse()
        {


            var taskController = new TaskController(_fixture.interfaceClassWithData.Object);


            var result = taskController.Post(null);


            Assert.IsType<BadRequestObjectResult>(result);

        }

        #endregion
    }
}