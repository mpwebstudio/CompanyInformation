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


        /// <summary>
        /// Get all employees for a selected company
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GenericResponse> GetEmployees(GetEmployeesRequest request)
        {
            return new GenericResponse
            {
                Data = await employee.All()
                .Where(x => x.CompanyEmployees.Any(z => z.CompanyID == request.CompanyID) && x.IsLive).Select(x => new GetEmployeesReponse
                {
                    CompanyID = request.CompanyID,
                    CompanyName = x.Companies.FirstOrDefault(z => z.ID == request.CompanyID).CompanyName,
                    ID = x.ID,
                    Email = x.Email,
                    Fullname = x.Fullname,
                    PreferedName = x.PreferedName,
                    Telephone = x.Telephone,
                    DelegatedPerson = x.DelegateAuthority.CompanyEmployee.Employee.Fullname,
                    DelegatedPersonID = x.DelegateAuthority.CompanyEmployeeID
                }).ToListAsync(),
                Status = true
            };
        }
        
        /// <summary>
        /// Get all live employees
        /// </summary>
        /// <returns></returns>
        public async Task<GenericResponse> GetAllEmployees()
        {
            return new GenericResponse
            {
                Data = await employee.All()
                    .Where(x => x.IsLive)
                    .Select(x => new EmployeeResponse
                    {
                        ID = x.ID,
                        Company = x.CompanyEmployees.Where(z => z.EmployeeID == x.ID).Select(d => new EmployeeCompanyResponse { CompanyID = d.CompanyID, CompanyName = d.Company.CompanyName}).ToList(),
                        DelegatedAuthorityID = x.DelegateAuthority.CompanyEmployeeID,
                        DelegatedAuthority = x.DelegateAuthority.CompanyEmployee.Employee.Fullname,
                        Email = x.Email,
                        Fullname = x.Fullname,
                        PreferedName = x.PreferedName,
                        Telephone = x.Telephone
                    })
                    .ToListAsync(),
                 Status = true
            };
        }

        public async Task<GenericResponse> UpdateEmployee(EmployeeResponse request)
        {
            var oldData = employee.All().Single(x => x.ID == request.ID);

            AutoMapper.Mapper.Map(request, oldData);

            employee.SaveChanges();

            return new GenericResponse
            {
                Data = await employee.All().Where(x => x.ID == oldData.ID).ProjectTo<EmployeeResponse>().SingleAsync(),
                Status = true
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

        public async Task<GenericResponse> GetSingleEmployee(int id)
        {
            var employeeDetails = employee.All().Where(x => x.ID == id && x.IsLive).Select(x => new EmployeeResponse
            {
                Company = x.CompanyEmployees.Where(z => z.EmployeeID == x.ID).Select(d => new EmployeeCompanyResponse { CompanyID = d.CompanyID, CompanyName = d.Company.CompanyName }).ToList(),
                ID = x.ID,
                Email = x.Email,
                Fullname = x.Fullname,
                PreferedName = x.PreferedName,
                Telephone = x.Telephone,
                DelegatedAuthorityID = x.DelegateAuthority.CompanyEmployeeID,
                DelegatedAuthority = x.DelegateAuthority.CompanyEmployee.Employee.Fullname
            }).FirstOrDefaultAsync();

            if (employeeDetails == null)
            {
                return new GenericResponse {Status = false, Message = "No User found"};
            }

            return new GenericResponse
            {
                Status = true,
                Data = employeeDetails.Result
            };
        }
    }
}