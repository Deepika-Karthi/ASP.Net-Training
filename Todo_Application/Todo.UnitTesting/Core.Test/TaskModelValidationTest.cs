using Todo_TaskService;
using Todo_TaskService.CoreLayer.CustomFilters;
using Todo_TaskService.CoreLayers.CustomException;

namespace Todo.UnitTest.CoreLayer.Test
{
    public class TaskModelValidationTest
    {

        #region PROPERTIES

        private TaskModelValidation _requestValidation = new TaskModelValidation();
        private ExceptionForTaskModelRequest _exceptionForValidation = new ExceptionForTaskModelRequest();

        #endregion

        #region TEST DATA
        public static IEnumerable<object[]> TestDataForPostAPI()
        {
            return new List<object[]>
            {
                new object[] {new  TaskDTO { TaskDescription = "Checking for post", TaskName = "Check Post API", TaskStatus = "hello" } },
                new object[] {new  TaskDTO { TaskDescription = "", TaskName = "Check Post API", TaskStatus = "started" } },
                new object[] {new  TaskDTO { TaskDescription = "  ", TaskName = "Check Post API", TaskStatus = "not started" } },
                new object[] {null}
             };

        }
        #endregion

        #region TEST LOGIC

        /// <summary>
        /// validate the request data for null ,empty string or whitespace, task status value
        /// </summary>
        /// <param name="requestData">Requested data by user</param>

        [Theory]
        [MemberData(nameof(TestDataForPostAPI))]

        public async Task ValidationLogic_TestRequestInputWithNullorSpace_ReturnErrorValidationException(TaskDTO requestData)
        {
           await Assert.ThrowsAsync<ExceptionForTaskModelRequest>(
                async() => _requestValidation.ValidationLogic(requestData));      


        }

        /// <summary>
        /// validate the request data for correct 
        /// </summary>

        [Fact]
        public void ValidationLogic_TestRequestInput_ReturnAsValid()
        {
            TaskDTO taskDTO = new TaskDTO() { TaskDescription = "brief description about task", TaskName = "name of the task", TaskStatus = "started" };
            string expectedResponse = "ValidState";

            var result = _requestValidation.ValidationLogic(taskDTO);

            Assert.Equal(expectedResponse, result);
        }

        #endregion
    }
}
