namespace CompaniesInfo.Services.Data.DelegateAuthority
{
    using System.Threading.Tasks;
    using Server.Common;
    using Server.DataTransferModels.DelegateAuthority;

    public interface IDelegateAuthorityService : IService
    {
        Task<AddDelegatedAuthorityResponse> AddDelegatedAuthority(AddDelegateAuthorityRequest request);
    }
}