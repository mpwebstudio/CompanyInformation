namespace CompaniesInfo.Server.DataTransferModels.Employee
{
    using System.Collections.Generic;
    using Common.Mapping;
    using Data.Models;

    public class EmployeeResponse : IMapFrom<Employee>
    {
        public int ID { get; set; }

        public string Fullname { get; set; }

        public string PreferedName { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public bool IsLive { get; set; } = true;

        public int? DelegatedAuthorityID { get; set; }

        public string DelegatedAuthority { get; set; }

        public List<EmployeeCompanyResponse> Company { get; set; }
    }
}