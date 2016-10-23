namespace CompaniesInfo.Server.DataTransferModels.Employee
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Common.Mapping;
    using Company;
    using Data.Models;

    public class GetEmployeesReponse : IMapFrom<Employee>, IMapFrom<Company>, IHaveCustomMapping
    {
        public int ID { get; set; }

        public string Fullname { get; set; }

        public string PreferedName { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public int? CompanyID { get; set; }

        public string CompanyName { get; set; }

        public string DelegatedPerson { get; set; }

        public int? DelegatedPersonID { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            //Mapper.CreateMap<Employee, GetEmployeesReponse>()
                //.ForMember(t => t.CompanyName, a => a.MapFrom(f => f.Companies.First().CompanyName))
                //.ForMember(t => t.CompanyID, a => a.MapFrom(f => f.Companies.First().ID));
                //.ForMember(t => t.DelegatedPerson,a => a.MapFrom(f => f.DelegateAuthority.CompanyEmployee.Employee.Fullname))
                //.ForMember(t => t.DelegatedPersonID, a => a.MapFrom(f => f.DelegateAuthority.CompanyEmployeeID));
        }
    }
}