namespace CompaniesInfo.Server.DataTransferModels.CompanyEmployee
{
    using Common.Mapping;
    using Data.Models;

    public class AddEmployeeToCompanyRequest : IMapFrom<CompanyEmployee>
    {
        public int CompanyID { get; set; }

        public int EmployeeID { get; set; }
    }
}