namespace ExampleService_WebApi.CoreLayers.CustomException
{
    [Serializable]
    public class CustomExceptionForRequestValidation: Exception
    {
        public CustomExceptionForRequestValidation()
        {
                
        }
        public CustomExceptionForRequestValidation(string message) 
            : base(string.Format("Request Data : {0}",message))
        { 

        }

    }
}
