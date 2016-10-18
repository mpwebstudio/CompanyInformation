namespace CompaniesInfo.Services.Data.CompanyEmployee
{
    using System.Threading.Tasks;
    using Server.Common;
    using Server.DataTransferModels.Company;
    using Server.DataTransferModels.CompanyEmployee;

    public interface ICompanyEmployeeService : IService
    {
        Task<AddEmployeeToCompanyResponse> AddEmployeeToCompany(AddEmployeeToCompanyRequest request);

        
    }
}