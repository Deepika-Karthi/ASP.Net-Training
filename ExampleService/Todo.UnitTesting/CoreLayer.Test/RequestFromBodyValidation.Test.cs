using ExampleService_WebApi;
using ExampleService_WebApi.CoreLayer.CustomFilters;
using ExampleService_WebApi.CoreLayers.CustomException;

namespace Todo.UnitTest.CoreLayer.Test
{
    public class RequestFromBodyValidationTest
    {

        #region PROPERTIES

        private RequestFromBodyValidation _requestValidation = new RequestFromBodyValidation();
        private CustomExceptionForRequestValidation _exceptionForValidation = new CustomExceptionForRequestValidation();

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
           await Assert.ThrowsAsync<CustomExceptionForRequestValidation>(
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
