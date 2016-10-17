namespace CompaniesInfo.Server.DataTransferModels.CompanyEmployee
{
    public class AddEmployeeToCompanyResponse
    {
        public int ID { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}