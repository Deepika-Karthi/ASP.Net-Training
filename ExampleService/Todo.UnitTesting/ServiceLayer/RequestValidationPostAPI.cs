﻿using ExampleService_WebApi;
using ExampleService_WebApi.CustomFilters;

namespace Todo.UnitTesting.ServiceLayer
{
    public class RequestValidationPostAPI
    {

        #region PROPERTIES

        PostAPIRequestValidation requestValidation = new PostAPIRequestValidation();

        #endregion

        #region TEST DATA
        public static IEnumerable<Object[]> TestDataForPostAPI()
        {
            return new List<object[]>
            {
               //new object[] {new  TaskDTO { TaskDescription = "asdf", TaskName = "Check Post API", TaskStatus = "asdf" } },
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

            var result = requestValidation.ValidationLogic(requestData);
            
            Assert.Equal("Provide Data to be added", result);

        }

        /// <summary>
        /// validate the request data for task status field
        /// </summary>

        [Fact]
        public void ValidationLogic_TestRequestInputforTaskStatus_ReturnErrorValidationStatus()
        {
            TaskDTO taskDTO = new TaskDTO() { TaskDescription = "brief description about task", TaskName = "name of the task", TaskStatus = "sdfgh" };

            var result = requestValidation.ValidationLogic(taskDTO);

            Assert.Equal("Task Status should be given as (Started/Completed/NotStarted)", result);
        }

        /// <summary>
        /// validate the request data for correct 
        /// </summary>

        [Fact]
        public void ValidationLogic_TestRequestInput_ReturnAsValid()
        {
            TaskDTO taskDTO = new TaskDTO() { TaskDescription = "brief description about task", TaskName = "name of the task", TaskStatus = "started" };

            var result = requestValidation.ValidationLogic(taskDTO);

            Assert.Equal("ValidState", result);
        }

        #endregion
    }
}
