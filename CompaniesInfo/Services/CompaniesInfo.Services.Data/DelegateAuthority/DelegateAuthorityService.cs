namespace CompaniesInfo.Services.Data.DelegateAuthority
{
    using System.Threading.Tasks;
    using CompaniesInfo.Data.Common.Repositories;
    using CompaniesInfo.Data.Models;
    using Server.DataTransferModels.DelegateAuthority;
    using System.Linq;

    public class DelegateAuthorityService : IDelegateAuthorityService
    {
        private readonly IRepository<DelegateAuthority> delegateAuthority;

        public DelegateAuthorityService(IRepository<DelegateAuthority> delegateAuthority)
        {
            this.delegateAuthority = delegateAuthority;
        }

        public async Task<AddDelegatedAuthorityResponse> AddDelegatedAuthority(AddDelegateAuthorityRequest request)
        {
            var companyEmploee = delegateAuthority.All()
                .FirstOrDefault(x => x.CompanyEmployee.EmployeeID == request.AuthorityEmployeeID);
            if (companyEmploee == null)
            {
                return new AddDelegatedAuthorityResponse {Message = "No employee found", Success = false};
            }
            var companyEmployee =
                    companyEmploee
                        .CompanyEmployee.ID;

                var delegateToAdd = new DelegateAuthority { CompanyEmployeeID = companyEmployee, EmployeeID = request.EmployeeID};

                delegateAuthority.Add(delegateToAdd);
            

            delegateAuthority.SaveChanges();

            return new AddDelegatedAuthorityResponse {Success = true};
        }

    }
}