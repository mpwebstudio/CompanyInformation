namespace CompaniesInfo.Services.Data.Company
{
    using System.Threading.Tasks;
    using Server.DataTransferModels.Company;

    public interface ICompanyService
    {
        Task<CompanyResponse> CreateCompanye(CreateCompanyRequest request);
    }
}