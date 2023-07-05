using ExampleService_WebApi.CoreLayers.CustomException;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace ExampleService_WebApi.CoreLayer.CustomFilters
{
    public class RequestFromBodyValidation
    {
        /// <summary>
        /// for validating the model state of request
        /// </summary>
        /// <param name="requestDTO">Task DTO request</param>
        /// <returns>Validation result as message</returns>
        /// 

        public string ValidationLogic(TaskDTO requestDTO)
        {

            if (requestDTO == null || requestDTO.TaskDescription == null || requestDTO.TaskStatus == null || requestDTO.TaskName == null)
            {
                throw new CustomExceptionForRequestValidation("Should not be null");
            }

            if (requestDTO.TaskDescription == string.Empty || requestDTO.TaskStatus == string.Empty || requestDTO.TaskName == string.Empty)
            {
                throw new CustomExceptionForRequestValidation("Should not be empty");
            }

            if (requestDTO.TaskDescription.Trim() == "" || requestDTO.TaskName.Trim() == "")
            {
                throw new CustomExceptionForRequestValidation("Should not be white space");
            }

            if (requestDTO.TaskStatus.ToLower() != "completed" && requestDTO.TaskStatus.ToLower() != "started" && requestDTO.TaskStatus.ToLower() != "notstarted")
            {               
                throw new CustomExceptionForRequestValidation("Task Status should be given as (Started/Completed/NotStarted)");
            }

            //if all the cases are failed then the state is valid
            return "ValidState";
        }
    }
}
