namespace CompaniesInfo.Services.Data.Company
{
    using System.Threading.Tasks;
    using Server.Common;
    using Server.DataTransferModels.Company;

    public interface ICompanyService : IService
    {
        Task<CompanyResponse> CreateCompany(CreateCompanyRequest request);
    }
}