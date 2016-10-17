namespace CompaniesInfo.Services.Data.Employee
{
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
    }
}