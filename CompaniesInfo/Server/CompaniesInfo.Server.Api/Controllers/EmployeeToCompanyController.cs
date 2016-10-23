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

        /// <summary>
        /// add single employee to company
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/employeeToCompany/addEmployeeToCompany")]
        public async Task<AddEmployeeToCompanyResponse> AddEmployeeToCompany([FromBody]AddEmployeeToCompanyRequest request)
        {
            return await companyEmployeeService.AddEmployeeToCompany(request);
        }

        /// <summary>
        /// update employee companies
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/employeeToCompany/updateEmployeeToCompany")]
        public async Task<UpdateEmployeeToCompanyResponse> UpdateEmployeeToCompany([FromBody] UpdateEmployeeToCompanyRequest request)
        {
            return await companyEmployeeService.UpdateEmployeesCompany(request);
        }

        /// <summary>
        /// Add employee to companies
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/employeeToCompany/addEmployeeToCompanies")]
        public async Task<AddEmployeeToCompanyResponse> AddEmployeeToCompanies([FromBody] UpdateEmployeeToCompanyRequest request)
        {
            return await companyEmployeeService.AddEmployeeToCompanies(request);
        }
    }
}