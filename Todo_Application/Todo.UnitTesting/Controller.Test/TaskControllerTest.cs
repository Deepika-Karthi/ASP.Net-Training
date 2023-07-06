using Todo_TaskService;
using Todo_TaskService.Controllers;
using Todo_TaskService.CoreLayer.CustomFilters;
using Microsoft.AspNetCore.Mvc;
using Todo.UnitTesting.ClassFixture;

namespace Todo.UnitTest.Controller.Test
{
    public class TaskControllerTest : IClassFixture<TaskInterfaceMock>
    {

        #region PROPERTIES

        private readonly TaskInterfaceMock _fixture;

        private TaskDTO _dummyDataForPostAPI = new TaskDTO { TaskDescription = "Checking for post test", TaskName = "Check Post API", TaskStatus = "Started" };

        private TaskModelValidation _requestValidation = new TaskModelValidation();

        #endregion

        #region TEST DATA
        public static IEnumerable<object[]> TestDataForPostAPI()
        {
            return new List<object[]>
            {
                new object[] {new  TaskDTO { TaskDescription = "asdf", TaskName = "Check Post API", TaskStatus = "asdf" } },
                new object[] {new  TaskDTO { TaskDescription = "", TaskName = "Check Post API", TaskStatus = "started" } },
                new object[] {new  TaskDTO { TaskDescription = "  ", TaskName = "Check Post API", TaskStatus = "not started" } },
                new object[] {null}
             };

        }
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
            var taskController = new TaskController(_fixture.interfaceClassWithData.Object, _requestValidation);

            var result = taskController.Get();

            Assert.IsType<OkObjectResult>(result);

        }

        /// <summary>
        /// test for get API when there is no data to return
        /// </summary>

        [Fact]
        public void Get_WhenDataNotFound_ReturnNotFoundResponse()
        {
            var taskController = new TaskController(_fixture.interfaceClassWithoutData.Object, _requestValidation);

            var result = taskController.Get();

            Assert.IsType<NotFoundObjectResult>(result);

        }

        /// <summary>
        /// test for post API when correct data is given
        /// </summary>

        [Fact]
        public void Post_WhenDataIsGiven_NeedToAdd()
        {
            var taskController = new TaskController(_fixture.interfaceClassWithData.Object, _requestValidation);

            var result = taskController.Post(_dummyDataForPostAPI);

            Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// test for post API when input is bad request
        /// </summary>

        [Theory]
        [MemberData(nameof(TestDataForPostAPI))]
        public void Post_WhenNullDataIsGiven_NeedToThrowBadResponse(TaskDTO taskDTO)
        {
            var taskController = new TaskController(_fixture.interfaceClassWithData.Object, _requestValidation);

            var result = taskController.Post(taskDTO);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        #endregion
    }
}