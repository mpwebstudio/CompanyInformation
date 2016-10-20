namespace CompaniesInfo.Server.DataTransferModels
{
    public class GenericResponse
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}