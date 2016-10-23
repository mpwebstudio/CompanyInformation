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
        public async Task<AddDelegatedAuthorityResponse> AddAuthority([FromBody]AddDelegateAuthorityRequest request)
        {
            return await delegateAuthirityService.AddDelegatedAuthority(request);
        }


        [HttpPost]
        [Route("api/delegatedAuthority/updateAuthority")]
        public async Task<AddDelegatedAuthorityResponse> UpdateAuthority([FromBody]GenericDelegatedAuthorityRequest request)
        {
            return await delegateAuthirityService.UpdateDelegatedAuthority(request);
        }

        [HttpPost]
        [Route("api/delegatedAuthority/deleteAuthority")]
        public async Task<AddDelegatedAuthorityResponse> DeleteAuthority([FromBody]GenericDelegatedAuthorityRequest request)
        {
            return await delegateAuthirityService.DeleteDelegatedAuthority(request);
        }
    }
}