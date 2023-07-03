using ExampleService_WebApi;
using ExampleService_WebApi.CustomFilters;
using Microsoft.AspNetCore.Mvc;
using Todo.UnitTesting.ClassFixture;

namespace Todo.UnitTesting.TestForControllers
{
    public class TaskControllerTest : IClassFixture<TaskInterfaceMock>
    {

        #region PROPERTIES

        private readonly TaskInterfaceMock _fixture;

        TaskDTO DummyDataForPostAPI = new TaskDTO { TaskDescription = "Checking for post test", TaskName = "Check Post API", TaskStatus = "Started" };
         static TaskDTO DummyDataForPostAPIwithNUll = new TaskDTO { TaskDescription = null, TaskName = "Check Post API", TaskStatus = "Started" };
        PostAPIRequestValidation APIRequestValidation = new PostAPIRequestValidation();

        #endregion

        #region TEST DATA
        public static IEnumerable<Object[]> TestDataForPostAPI()
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

            var taskController = new TaskController(_fixture.interfaceClassWithData.Object,APIRequestValidation);


            var result = taskController.Get();


            Assert.IsType<OkObjectResult>(result);

        }

        /// <summary>
        /// test for get API when there is no data to return
        /// </summary>

        [Fact]
        public void Get_WhenDataNotFound_ReturnNotFoundResponse()
        {

            var taskController = new TaskController(_fixture.interfaceClassWithoutData.Object, APIRequestValidation);


            var result = taskController.Get();


            Assert.IsType<NotFoundObjectResult>(result);

        }

        /// <summary>
        /// test for post API when correct data is given
        /// </summary>

        [Fact]
        public void Post_WhenDataIsGiven_NeedToAdd()
        {


            var taskController = new TaskController(_fixture.interfaceClassWithData.Object, APIRequestValidation);

            var result = taskController.Post(DummyDataForPostAPI);


            Assert.IsType<OkObjectResult>(result);

        }

        /// <summary>
        /// test for post API when input is bad request
        /// </summary>

        [Theory]
        [MemberData(nameof(TestDataForPostAPI))]
        public void Post_WhenNullDataIsGiven_NeedToThrowBadResponse(TaskDTO taskDTO)
        {


            var taskController = new TaskController(_fixture.interfaceClassWithData.Object,APIRequestValidation);

           
            var result = taskController.Post(taskDTO);


            Assert.IsType<BadRequestObjectResult>(result);

        }

        #endregion
    }
}