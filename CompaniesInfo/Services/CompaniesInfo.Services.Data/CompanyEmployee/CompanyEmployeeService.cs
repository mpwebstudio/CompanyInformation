namespace CompaniesInfo.Services.Data.CompanyEmployee
{
    using System;
    using System.Linq;
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

        /// <summary>
        /// Add single employee to company, when creating a copmay
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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

        /// <summary>
        /// When creating a new employee
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AddEmployeeToCompanyResponse> AddEmployeeToCompanies(UpdateEmployeeToCompanyRequest request)
        {
            foreach (var compId in request.CompanyID)
            {
                companyEmployee.Add(new CompanyEmployee {CompanyID = compId, EmployeeID = request.EmployeeID});
            }

            try { await companyEmployee.SaveChangesAsync(); }
            catch (Exception) { return new AddEmployeeToCompanyResponse {Success = false, Message = "Cant add employees to company"};}

            return new AddEmployeeToCompanyResponse {Success = true};
        }

        /// <summary>
        /// update employee to company when updating company
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AddEmployeeToCompanyResponse> UpdateEmployeeToCompany(AddEmployeeToCompanyRequest request)
        {
            var oldData = companyEmployee.All().SingleOrDefault(x => x.CompanyID == request.CompanyID && x.EmployeeID == request.OldEmployeeID);

            if (oldData == null)
            {
                return new AddEmployeeToCompanyResponse
                {
                    Success = false,
                    Message = "No such a company in CompanyEmployee table"
                };
            }

            oldData.EmployeeID = request.EmployeeID;
            try { await companyEmployee.SaveChangesAsync(); }
            catch(Exception ex) { return new AddEmployeeToCompanyResponse { ID = oldData.ID, Success = false, Message = "No employee found" }; }

            return new AddEmployeeToCompanyResponse {ID = oldData.ID, Success = true};
        }


        //TODO: Refactor it!!!
        public async Task<UpdateEmployeeToCompanyResponse> UpdateEmployeesCompany(UpdateEmployeeToCompanyRequest request)
        {
            var oldData = companyEmployee.All().Where(x => x.EmployeeID == request.EmployeeID);

            foreach (var toDelete in oldData)
            {
                companyEmployee.Delete(toDelete);
            }

            await companyEmployee.SaveChangesAsync();

            foreach (var company in request.CompanyID)
            {
                companyEmployee.Add(new CompanyEmployee {CompanyID = company, EmployeeID = request.EmployeeID});
            }

            await companyEmployee.SaveChangesAsync();

            return new UpdateEmployeeToCompanyResponse {Success = true};
        }

        public async Task<AddEmployeeToCompanyResponse> DeleteAllEmployeeToCompany(DeleteEmployeeToCompanyRequest request)
        {
            var toDelete = companyEmployee.All().Where(x => x.EmployeeID == request.EmployeeID);

            foreach (var record in toDelete)
            {
                companyEmployee.Delete(record);
            }

            await companyEmployee.SaveChangesAsync();

            return new AddEmployeeToCompanyResponse {Success = true};
        }
    }
}