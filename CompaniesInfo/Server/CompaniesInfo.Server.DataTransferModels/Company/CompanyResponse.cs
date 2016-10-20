namespace CompaniesInfo.Server.DataTransferModels.Company
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class CompanyResponse : IMapFrom<Company>, IMapFrom<Employee>, IHaveCustomMapping
    {
        public int ID { get; set; }

        public string CompanyName { get; set; }

        public int PrimeContactID { get; set; }

        public bool IsLive { get; set; }

        public string Message { get; set; }

        public string ContactName { get; set; }

        public string ContactNumber { get; set; }
        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<Company, CompanyResponse>()
                .ForMember(t => t.ContactNumber, a => a.MapFrom(f => f.Employee.Telephone))
                .ForMember(t => t.ContactName, a => a.MapFrom(f => f.Employee.Fullname))
                .ForMember(t => t.PrimeContactID, a => a.MapFrom(f => f.EmployeeID));
        }
    }
}