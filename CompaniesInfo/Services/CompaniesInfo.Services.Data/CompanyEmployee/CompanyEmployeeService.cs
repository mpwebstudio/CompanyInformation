namespace CompaniesInfo.Services.Data.CompanyEmployee
{
    using System;
    using System.Threading.Tasks;
    using CompaniesInfo.Data.Common.Repositories;
    using CompaniesInfo.Data.Models;
    using Server.DataTransferModels.CompanyEmployee;

    public class CompanyEmployeeService : ICompanyEmployeeService
    {
        private readonly IRepository<CompanyEmployee> companyEmployee;

        public CompanyEmployeeService(IRepository<CompanyEmployee> companyEmployee)
        {
            this.companyEmployee = companyEmployee;
        }

        public async Task<AddEmployeeToCompanyResponse> AddEmployeeToCompany(AddEmployeeToCompanyRequest request)
        {
            var employee = AutoMapper.Mapper.Map<CompanyEmployee>(request);

            companyEmployee.Add(employee);

            try
            {
                await companyEmployee.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new AddEmployeeToCompanyResponse
                {
                    Success = false,
                    Message = "Unsuccessful"
                };
            }

            return new AddEmployeeToCompanyResponse {Success = true, Message = "Successful", ID = employee.ID};
        }
    }
}