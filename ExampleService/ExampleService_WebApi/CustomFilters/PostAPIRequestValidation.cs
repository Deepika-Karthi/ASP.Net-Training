

namespace ExampleService_WebApi.CustomFilters
{
    public class PostAPIRequestValidation
    {
        /// <summary>
        /// for validating the model state of request
        /// </summary>
        /// <param name="requestDTO">Task DTO request</param>
        /// <returns>Validation result as message</returns>
        public string ValidationLogic(TaskDTO requestDTO)
        {

            if (requestDTO == null || requestDTO.TaskDescription == null || requestDTO.TaskStatus == null || requestDTO.TaskName == null)
            {
                return "Provide Data to be added";

            }

            if (requestDTO.TaskDescription == string.Empty || requestDTO.TaskStatus == string.Empty || requestDTO.TaskName == string.Empty)
            {
                return "Provide Data to be added";
            }

            if (requestDTO.TaskDescription.Trim()=="" || requestDTO.TaskName.Trim() == "")
            {
                return "Provide Data to be added";
            }


            if (requestDTO.TaskStatus.ToLower() != "completed" && requestDTO.TaskStatus.ToLower() != "started" && requestDTO.TaskStatus.ToLower() != "notstarted")
            {
                return "Task Status should be given as (Started/Completed/NotStarted)";
            }

           
            //if all the cases are failed then the state is valid
            return "ValidState";
        }
    }
}
