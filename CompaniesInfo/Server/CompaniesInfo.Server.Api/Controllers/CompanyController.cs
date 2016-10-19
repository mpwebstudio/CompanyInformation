namespace CompaniesInfo.Server.Api.Controllers
{
    using System.Collections.Generic;
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
        [Route("api/company/createCompany")]
        public async Task<CompanyResponse> CreateCompany([FromBody]CreateCompanyRequest request)
        {
            return await companyService.CreateCompany(request);
        }

        [HttpGet]
        [Route("api/company/getCompany/{companyId}")]
        public async Task<CompanyResponse> GetCompany(int companyId)
        {
            return await companyService.GetCompany(new GetCompanyRequest {CompanyID = companyId});
        }

        [HttpGet]
        [Route("api/company/getAllCompany")]
        public async Task<IEnumerable<CompanyResponse>> GetAllCompany()
        {
            return await companyService.GetAllCompany();
        }

        [HttpPost]
        [Route("api/company/updateCompanyDetails")]
        public async Task<CompanyResponse> UpdateCompanyResponse([FromBody]CompanyResponse request)
        {
            return await companyService.UpdateCompany(request);
        }

        [HttpDelete]
        [Route("api/company/deleteCompany")]
        public async Task<DeleteCompanyResponse> DeleteCompany([FromBody] GetCompanyRequest request)
        {
            return await companyService.DeleteCompany(request);
        }
    }
}