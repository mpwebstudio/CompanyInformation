namespace CompaniesInfo.Services.Data.Company
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using CompaniesInfo.Data.Common.Repositories;
    using CompaniesInfo.Data.Models;
    using Server.DataTransferModels.Company;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;

    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> company;

        public CompanyService(IRepository<Company> company)
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
                EmployeeID = request.PrimeContactID,
                IsLive = true
            };

            company.Add(companyToAdd);

            company.SaveChanges();

            return await company.All().Where(x => x.ID == companyToAdd.ID).ProjectTo<CompanyResponse>().SingleAsync();
        }

        public async Task<CompanyResponse> GetCompany(GetCompanyRequest request)
        {
            return await company.All().Where(x => x.ID == request.CompanyID && x.IsLive).ProjectTo<CompanyResponse>().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CompanyResponse>> GetAllCompany()
        {
            return company.All().Where(x => x.IsLive).ProjectTo<CompanyResponse>();
        }

        public async Task<CompanyResponse> UpdateCompany(CompanyResponse request)
        {
            var oldData = company.GetById(request);

            AutoMapper.Mapper.Map(request, oldData);
            company.SaveChanges();

            return await company.All().Where(x => x.ID == oldData.ID).ProjectTo<CompanyResponse>().SingleAsync();
        }

        public async Task<DeleteCompanyResponse> DeleteCompany(GetCompanyRequest request)
        {
            var oldData = company.All().SingleOrDefault(x => x.ID == request.CompanyID);

            if (oldData == null)
            {
                return new DeleteCompanyResponse {Message = "Company not found", Success = false};
            }

            oldData.IsLive = false;
            company.SaveChanges();

            return new DeleteCompanyResponse {Success = true};
        }
    }
}