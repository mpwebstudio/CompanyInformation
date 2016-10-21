namespace CompaniesInfo.Services.Data.Employee
{
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using CompaniesInfo.Data.Common.Repositories;
    using CompaniesInfo.Data.Models;
    using Server.DataTransferModels.Employee;
    using AutoMapper.QueryableExtensions;
    using Server.DataTransferModels;

    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> employee;

        public EmployeeService(IRepository<Employee> employee)
        {
            this.employee = employee;
        }

        public async Task<GenericResponse> CreateEmployee(CreateEmployeeRequest request)
        {
            var emp = AutoMapper.Mapper.Map<Employee>(request);

            employee.Add(emp);
            employee.SaveChanges();

            return new GenericResponse
            {
                Data = await employee.All().Where(x => x.ID == emp.ID).ProjectTo<EmployeeResponse>().SingleAsync(),
                Status = true
            };
        }

        public async Task<GenericResponse> GetEmployees(GetEmployeesRequest request)
        {
            return new GenericResponse
            {
                Data = await employee.All()
                    .Where(x => x.CompanyEmployees.Any(z => z.CompanyID == request.CompanyID) && x.IsLive)
                    .ProjectTo<GetEmployeesReponse>().ToListAsync()
            };
        }

        public async Task<GenericResponse> GetAllEmployees()
        {
            return new GenericResponse
            {
                Data = await employee.All()
                    .Where(x => x.IsLive).ProjectTo<GetEmployeesReponse>().ToListAsync()
            };
        }

        public async Task<GenericResponse> UpdateEmployee(EmployeeResponse request)
        {
            var oldData = employee.All().Single(x => x.ID == request.ID);

            AutoMapper.Mapper.Map(request, oldData);

            employee.SaveChanges();

            return new GenericResponse
            {
                Data = await employee.All().Where(x => x.ID == oldData.ID).ProjectTo<EmployeeResponse>().SingleAsync()
            };
        }

        public async Task<GenericResponse> DeleteEmployee(DeleteEmployeeRequest request)
        {
            var oldData = await employee.All().SingleOrDefaultAsync(x => x.ID == request.EmployeeID);

            if (oldData == null)
            {
                return new GenericResponse
                {
                    Message = "No employee found",
                    Status = false
                };
            }

            oldData.IsLive = false;
            employee.SaveChanges();

            return new GenericResponse { Status = true };
        }
    }
}