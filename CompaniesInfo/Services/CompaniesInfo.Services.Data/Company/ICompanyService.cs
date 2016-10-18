namespace CompaniesInfo.Services.Data.Company
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Server.Common;
    using Server.DataTransferModels.Company;

    public interface ICompanyService : IService
    {
        Task<CompanyResponse> CreateCompany(CreateCompanyRequest request);

        Task<CompanyResponse> GetCompany(GetCompanyRequest request);

        Task<CompanyResponse> UpdateCompany(CompanyResponse request);

        Task<DeleteCompanyResponse> DeleteCompany(GetCompanyRequest request);

        Task<IEnumerable<CompanyResponse>> GetAllCompany();
    }
}