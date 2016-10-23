namespace CompaniesInfo.Services.Data.CompanyEmployee
{
    using System.Threading.Tasks;
    using Server.Common;
    using Server.DataTransferModels.CompanyEmployee;

    public interface ICompanyEmployeeService : IService
    {
        Task<AddEmployeeToCompanyResponse> AddEmployeeToCompany(AddEmployeeToCompanyRequest request);

        Task<AddEmployeeToCompanyResponse> AddEmployeeToCompanies(UpdateEmployeeToCompanyRequest request);

        Task<AddEmployeeToCompanyResponse> UpdateEmployeeToCompany(AddEmployeeToCompanyRequest request);

        Task<UpdateEmployeeToCompanyResponse> UpdateEmployeesCompany(UpdateEmployeeToCompanyRequest request);

        Task<AddEmployeeToCompanyResponse> DeleteAllEmployeeToCompany(DeleteEmployeeToCompanyRequest request);
    }
}