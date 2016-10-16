namespace CompaniesInfo.Server.DataTransferModels.Company
{
    using Common.Mapping;
    using Data.Models;

    public class CompanyResponse : IMapFrom<Company>
    {
        public int ID { get; set; }

        public string CompanyName { get; set; }

        public int PrimeContactID { get; set; }

        public bool IsLive { get; set; }

        public string Message { get; set; }
    }
}