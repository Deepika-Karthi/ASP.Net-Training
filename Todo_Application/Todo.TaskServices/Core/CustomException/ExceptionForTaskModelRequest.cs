namespace Todo_TaskService.CoreLayers.CustomException

{
    /// <summary>
        /// Exceptions for Invalid TaskModel request
        /// </summary>

    [Serializable]
    public class ExceptionForTaskModelRequest: Exception
    {
        public ExceptionForTaskModelRequest()
        {
                
        }
        public ExceptionForTaskModelRequest(string message) 
            : base(string.Format("Request Data : {0}",message))
        { 

        }

    }
}
