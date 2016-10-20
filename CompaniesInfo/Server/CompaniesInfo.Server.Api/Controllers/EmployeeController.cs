namespace CompaniesInfo.Server.Api.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using DataTransferModels;
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
        public async Task<GenericResponse> CreateEmployee(CreateEmployeeRequest request)
        {
            return await employeeService.CreateEmployee(request);
        }

        [HttpGet]
        [Route("api/employee/getemployees/{companyId}")]
        public async Task<GenericResponse> GetEmployees(int companyId)
        {
            return await employeeService.GetEmployees(new GetEmployeesRequest {CompanyID = companyId});
        }

        [HttpGet]
        [Route("api/employee/getAllEmployees/")]
        public async Task<GenericResponse> GetAllEmployees()
        {
            return await employeeService.GetAllEmployees();
        }

        [HttpPost]
        [Route("api/employee/updateEmployeeDetails")]
        public async Task<GenericResponse> UpdateEmployeedetails([FromBody]EmployeeResponse request)
        {
            return await employeeService.UpdateEmployee(request);
        }

        [HttpDelete]
        [Route("api/employee/deleteEmployee")]
        public async Task<GenericResponse> DeleteEmployee([FromBody] DeleteEmployeeRequest request)
        {
            return await employeeService.DeleteEmployee(request);
        }
    }
}