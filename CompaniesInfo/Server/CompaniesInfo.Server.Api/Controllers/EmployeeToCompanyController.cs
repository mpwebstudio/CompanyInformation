namespace CompaniesInfo.Server.Api.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using DataTransferModels.CompanyEmployee;
    using Services.Data.CompanyEmployee;

    public class EmployeeToCompanyController : ApiController
    {
        private readonly ICompanyEmployeeService companyEmployeeService;

        public EmployeeToCompanyController(ICompanyEmployeeService companyEmployeeService)
        {
            this.companyEmployeeService = companyEmployeeService;
        }

        [HttpPost]
        [Route("api/employeeToCompany/addEmployeeToCompany")]
        public async Task<AddEmployeeToCompanyResponse> AddEmployeeToCompany([FromBody] AddEmployeeToCompanyRequest request)
        {
            return await companyEmployeeService.AddEmployeeToCompany(request);
        }
    }
}