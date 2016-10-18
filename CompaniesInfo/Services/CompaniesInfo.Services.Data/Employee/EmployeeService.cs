namespace CompaniesInfo.Services.Data.Employee
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using CompaniesInfo.Data.Common.Repositories;
    using CompaniesInfo.Data.Models;
    using Server.DataTransferModels.Employee;
    using AutoMapper.QueryableExtensions;

    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> employee;

        public EmployeeService(IRepository<Employee> employee)
        {
            this.employee = employee;
        }

        public async Task<EmployeeResponse> CreateEmployee(CreateEmployeeRequest request)
        {
            var emp = AutoMapper.Mapper.Map<Employee>(request);

            employee.Add(emp);
            employee.SaveChanges();

            return await employee.All().Where(x => x.ID == emp.ID).ProjectTo<EmployeeResponse>().SingleAsync();
        }

        public async Task<IEnumerable<GetEmployeesReponse>> GetEmployees(GetEmployeesRequest request)
        {
            return employee.All()
                    .Where(x => x.CompanyEmployees.Any(z => z.CompanyID == request.CompanyID) && x.IsLive)
                    .ProjectTo<GetEmployeesReponse>();
        }

        public async Task<EmployeeResponse> UpdateEmployee(EmployeeResponse request)
        {
            var oldData = employee.GetById(request);

            AutoMapper.Mapper.Map(request, oldData);

            employee.SaveChanges();

            return employee.All().Where(x => x.ID == oldData.ID).ProjectTo<EmployeeResponse>().Single();
        }

        public async Task<DeleteEmployeeResponse> DeleteEmployee(DeleteEmployeeRequest request)
        {
            var oldData = employee.All().SingleOrDefaultAsync(x => x.ID == request.EmployeeID);

            if (oldData == null)
            {
                return new DeleteEmployeeResponse {Message = "No employee found", Success = false};
            }

            oldData.Result.IsLive = false;
            employee.SaveChanges();

            return new DeleteEmployeeResponse {Success = true};
        }
    }
}