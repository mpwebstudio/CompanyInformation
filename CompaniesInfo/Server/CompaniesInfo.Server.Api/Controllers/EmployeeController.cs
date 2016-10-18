namespace CompaniesInfo.Server.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;
    using DataTransferModels.Employee;
    using Services.Data.Employee;

    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost]
        [Route("api/employee/createemployee")]
        public async Task<EmployeeResponse> CreateEmployee(CreateEmployeeRequest request)
        {
            return await employeeService.CreateEmployee(request);
        }

        [HttpGet]
        [Route("api/employee/getemployees/{companyId:int}")]
        public async Task<IEnumerable<GetEmployeesReponse>> GetEmployees(int companyId)
        {
            return await employeeService.GetEmployees(new GetEmployeesRequest {CompanyID = companyId});
        }

        [HttpPost]
        [Route("api/employee/updateEmployeeDetails")]
        public async Task<EmployeeResponse> UpdateEmployeedetails([FromBody]EmployeeResponse request)
        {
            return await employeeService.UpdateEmployee(request);
        }

        [HttpDelete]
        [Route("api/employee/deleteEmployee")]
        public async Task<DeleteEmployeeResponse> DeleteEmployee([FromBody] DeleteEmployeeRequest request)
        {
            return await employeeService.DeleteEmployee(request);
        }
    }
}