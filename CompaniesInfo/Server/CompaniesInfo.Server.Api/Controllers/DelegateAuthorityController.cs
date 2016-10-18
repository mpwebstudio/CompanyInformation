namespace CompaniesInfo.Server.Api.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using DataTransferModels.DelegateAuthority;
    using Services.Data.DelegateAuthority;

    public class DelegateAuthorityController : ApiController
    {
        private readonly IDelegateAuthorityService delegateAuthirityService;

        public DelegateAuthorityController(IDelegateAuthorityService delegateAuthirityService)
        {
            this.delegateAuthirityService = delegateAuthirityService;
        }

        [HttpPost]
        [Route("api/delegatedAuthority/addAuthority")]
        public async Task<AddDelegatedAuthorityResponse> AddAuthority(AddDelegateAuthorityRequest request)
        {
            return await delegateAuthirityService.AddDelegatedAuthority(request);
        }
    }
}