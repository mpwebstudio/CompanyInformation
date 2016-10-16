namespace CompaniesInfo.Data.Models
{
    public class Company
    {
        public int ID { get; set; }

        public string CompanyName { get; set; }

        public int PrimeContactID { get; set; }

        public bool IsLive { get; set; }
    }
}