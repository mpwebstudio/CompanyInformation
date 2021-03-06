﻿namespace CompaniesInfo.Server.DataTransferModels.Company
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using Employee;

    public class CompanyResponse : IMapFrom<Company>, IMapFrom<Employee>, IMapFrom<CreateEmployeeRequest>, IMapFrom<EmployeeResponse>, IHaveCustomMapping
    {
        public int ID { get; set; }

        public string CompanyName { get; set; }

        public int? PrimeContactID { get; set; }

        public bool IsLive { get; set; } = true;

        public string Message { get; set; }

        public string ContactName { get; set; }

        public string ContactNumber { get; set; }

        public string ContactEmail { get; set; }

        public string ContactPreferName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<Company, CompanyResponse>()
                .ForMember(t => t.ContactNumber, a => a.MapFrom(f => f.Employee.Telephone))
                .ForMember(t => t.ContactName, a => a.MapFrom(f => f.Employee.Fullname))
                .ForMember(t => t.PrimeContactID, a => a.MapFrom(f => f.EmployeeID))
                .ForMember(t => t.ContactEmail, a => a.MapFrom(f => f.Employee.Email))
                .ForMember(t => t.ContactPreferName, a => a.MapFrom(f => f.Employee.PreferedName)).ReverseMap();

            Mapper.CreateMap<CompanyResponse, CreateEmployeeRequest>()
                .ForMember(t => t.Fullname, a => a.MapFrom(f => f.ContactName))
                .ForMember(t => t.PreferedName, a => a.MapFrom(f => f.ContactPreferName))
                .ForMember(t => t.Email, a => a.MapFrom(f => f.ContactEmail))
                .ForMember(t => t.Telephone, a => a.MapFrom(f => f.ContactNumber));

            Mapper.CreateMap<CompanyResponse, EmployeeResponse>()
                .ForMember(t => t.ID, a => a.MapFrom(f => f.PrimeContactID))
                .ForMember(t => t.Fullname, a => a.MapFrom(f => f.ContactName))
                .ForMember(t => t.PreferedName, a => a.MapFrom(f => f.ContactPreferName))
                .ForMember(t => t.Email, a => a.MapFrom(f => f.ContactEmail))
                .ForMember(t => t.Telephone, a => a.MapFrom(f => f.ContactNumber));

        }
    }
}