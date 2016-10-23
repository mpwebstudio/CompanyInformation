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
    using CompanyEmployee;
    using Employee;
    using Server.DataTransferModels.Employee;

    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> company;
        private readonly ICompanyEmployeeService _companyEmployee;
        private readonly IEmployeeService _employeeService;

        public CompanyService(IRepository<Company> company, IEmployeeService employeeService, ICompanyEmployeeService companyEmployeeService)
        {
            this.company = company;
            this._employeeService = employeeService;
            this._companyEmployee = companyEmployeeService;

        }

        public async Task<CompanyResponse> CreateCompany(CreateCompanyRequest request)
        {
            var companyNameCheck = await company.All().FirstOrDefaultAsync(x => x.CompanyName == request.CompanyName);
            if (companyNameCheck != null)
            {
                return new CompanyResponse { Message = "Company exist" };
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
            var oldData = company.All().Single(x => x.ID == request.ID);

            if (request.PrimeContactID != null)
            {
                //if same eployee with diferent data
                if (request.PrimeContactID.Value == oldData.EmployeeID)
                {
                    var employee = AutoMapper.Mapper.Map<EmployeeResponse>(request);
                    await _employeeService.UpdateEmployee(employee);

                    AutoMapper.Mapper.Map(request, oldData);
                    company.SaveChanges();

                    return await company.All().Where(x => x.ID == oldData.ID).ProjectTo<CompanyResponse>().SingleAsync();
                }

                //if existing employee
                await _companyEmployee.UpdateEmployeeToCompany(new Server.DataTransferModels.CompanyEmployee.
                    AddEmployeeToCompanyRequest
                {
                    CompanyID = request.ID,
                    EmployeeID = request.PrimeContactID.Value,
                    OldEmployeeID = oldData.EmployeeID
                });
            }
            
            //If is a new Employee
            if (request.PrimeContactID == null)
            {
                var req = AutoMapper.Mapper.Map<CreateEmployeeRequest>(request);

                var empResult = await _employeeService.CreateEmployee(req);
                if (!empResult.Success)
                {
                    return new CompanyResponse { Message = "Something went wrong" };
                }

                await _companyEmployee.UpdateEmployeeToCompany(new Server.DataTransferModels.CompanyEmployee.
                    AddEmployeeToCompanyRequest
                {
                    CompanyID = request.ID,
                    EmployeeID = (empResult.Data as EmployeeResponse).ID,
                    OldEmployeeID = oldData.EmployeeID
                });

                request.PrimeContactID = (empResult.Data as EmployeeResponse).ID;
            }
            
            oldData.CompanyName = request.CompanyName;
            oldData.EmployeeID = request.PrimeContactID.Value;
            company.SaveChanges();

            return await company.All().Where(x => x.ID == oldData.ID).ProjectTo<CompanyResponse>().SingleAsync();
        }

        public async Task<DeleteCompanyResponse> DeleteCompany(GetCompanyRequest request)
        {
            var oldData = company.All().SingleOrDefault(x => x.ID == request.CompanyID);

            if (oldData == null)
            {
                return new DeleteCompanyResponse { Message = "Company not found", Success = false };
            }

            oldData.IsLive = false;
            company.SaveChanges();

            return new DeleteCompanyResponse { Success = true };
        }
    }
}