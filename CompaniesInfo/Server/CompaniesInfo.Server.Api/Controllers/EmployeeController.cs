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

        [HttpGet]
        [Route("api/employee/getSingleEmployee/{id}")]
        public async Task<GenericResponse> GetSingleEmployee([FromUri] int id)
        {
            return await employeeService.GetSingleEmployee(id);
        }

        [HttpPost]
        [Route("api/employee/createemployee")]
        public async Task<GenericResponse> CreateEmployee([FromBody]CreateEmployeeRequest request)
        {
            return await employeeService.CreateEmployee(request);
        }
        /// <summary>
        /// Get employees for a selected company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/employee/getemployees/{companyId}")]
        public async Task<GenericResponse> GetEmployees(int companyId)
        {
            return await employeeService.GetEmployees(new GetEmployeesRequest {CompanyID = companyId});
        }
        
        /// <summary>
        /// Get all live employees
        /// </summary>
        /// <returns></returns>
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

        [HttpPost]
        [Route("api/employee/deleteEmployee")]
        public async Task<GenericResponse> DeleteEmployee([FromBody] DeleteEmployeeRequest request)
        {
            return await employeeService.DeleteEmployee(request);
        }
    }
}