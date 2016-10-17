namespace CompaniesInfo.Server.Api.Controllers
{
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
    }
}