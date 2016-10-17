namespace CompaniesInfo.Server.Api.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using DataTransferModels.Company;
    using Services.Data.Company;

    public class CompanyController : ApiController
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpPost]
        [Route("api/company/createcompany")]
        public async Task<CompanyResponse> CreateCompany([FromBody]CreateCompanyRequest request)
        {
            return await companyService.CreateCompany(request);
        }
    }
}