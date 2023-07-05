using ExampleService_WebApi;
using ExampleService_WebApi.Ports.CustomFilters;

namespace Todo.UnitTesting.ServiceLayer
{
    public class RequestFromBodyValidationTest
    {

        #region PROPERTIES

        RequestFromBodyValidation requestValidation = new RequestFromBodyValidation();

        #endregion

        #region TEST DATA
        public static IEnumerable<Object[]> TestDataForPostAPI()
        {
            return new List<object[]>
            {
               
                new object[] {new  TaskDTO { TaskDescription = "", TaskName = "Check Post API", TaskStatus = "started" } },
                new object[] {new  TaskDTO { TaskDescription = "  ", TaskName = "Check Post API", TaskStatus = "not started" } },
                new object[] {null}
             };

        }
        #endregion

        #region TEST LOGIC

        /// <summary>
        /// validate the request data for null ,empty string or whitespace
        /// </summary>
        /// <param name="requestData">Requested data by user</param>

        [Theory]
        [MemberData(nameof(TestDataForPostAPI))]

        public void ValidationLogic_TestRequestInputWithNullorSpace_ReturnErrorValidationStatus(TaskDTO requestData)
        {
            string expectedResponse = "Provide Data to be added";

            var result = requestValidation.ValidationLogic(requestData);
            
            Assert.Equal(expectedResponse, result);

        }

        /// <summary>
        /// validate the request data for task status field
        /// </summary>

        [Fact]
        public void ValidationLogic_TestRequestInputforTaskStatus_ReturnErrorValidationStatus()
        {
            TaskDTO taskDTO = new TaskDTO() { TaskDescription = "brief description about task", TaskName = "name of the task", TaskStatus = "sdfgh" };
            string expectedResponse = "Task Status should be given as (Started/Completed/NotStarted)";

            var result = requestValidation.ValidationLogic(taskDTO);

            Assert.Equal(expectedResponse, result);
        }

        /// <summary>
        /// validate the request data for correct 
        /// </summary>

        [Fact]
        public void ValidationLogic_TestRequestInput_ReturnAsValid()
        {
            TaskDTO taskDTO = new TaskDTO() { TaskDescription = "brief description about task", TaskName = "name of the task", TaskStatus = "started" };
            string expectedResponse = "ValidState";

            var result = requestValidation.ValidationLogic(taskDTO);

            Assert.Equal(expectedResponse, result);
        }

        #endregion
    }
}
