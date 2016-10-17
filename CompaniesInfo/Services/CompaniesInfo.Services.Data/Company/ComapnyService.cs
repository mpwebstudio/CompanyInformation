namespace CompaniesInfo.Services.Data.Company
{
    using System.Data.Entity;
    using CompaniesInfo.Data.Common.Repositories;
    using CompaniesInfo.Data.Models;
    using Server.DataTransferModels.Company;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;

    public class ComapnyService : ICompanyService
    {
        private readonly IRepository<Company> company;

        public ComapnyService(IRepository<Company> company)
        {
            this.company = company;
        }

        public async Task<CompanyResponse> CreateCompany(CreateCompanyRequest request)
        {
            var companyNameCheck = await company.All().FirstOrDefaultAsync(x => x.CompanyName == request.CompanyName);
            if (companyNameCheck != null)
            {
                return new CompanyResponse {Message = "Company exist"};
            }

            var companyToAdd = new Company
            {
                CompanyName = request.CompanyName,
                PrimeContactID = request.PrimeContactID,
            };

            company.Add(companyToAdd);

            company.SaveChanges();

            return await company.All().Where(x => x.ID == companyToAdd.ID).ProjectTo<CompanyResponse>().FirstOrDefaultAsync();
        }
    }
}