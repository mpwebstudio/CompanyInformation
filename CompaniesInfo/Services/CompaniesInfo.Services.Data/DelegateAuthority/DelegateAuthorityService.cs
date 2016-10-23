namespace CompaniesInfo.Services.Data.DelegateAuthority
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using CompaniesInfo.Data.Common.Repositories;
    using CompaniesInfo.Data.Models;
    using Server.DataTransferModels.DelegateAuthority;
    using System.Linq;

    public class DelegateAuthorityService : IDelegateAuthorityService
    {
        private readonly IRepository<DelegateAuthority> delegateAuthority;
        private readonly IRepository<Employee> employee;

        public DelegateAuthorityService(IRepository<DelegateAuthority> delegateAuthority, IRepository<Employee> employee)
        {
            this.delegateAuthority = delegateAuthority;
            this.employee = employee;
        }

        public async Task<AddDelegatedAuthorityResponse> AddDelegatedAuthority(AddDelegateAuthorityRequest request)
        {
            var companyEmploee = employee.All()
                .FirstOrDefault(x => x.ID == request.AuthorityEmployeeID);
            if (companyEmploee == null)
            {
                return new AddDelegatedAuthorityResponse {Message = "No employee found", Success = false};
            }
            var companyEmployee = companyEmploee.ID;

                var delegateToAdd = new DelegateAuthority { CompanyEmployeeID = companyEmployee, EmployeeID =  request.EmployeeID};

                delegateAuthority.Add(delegateToAdd);
            
            delegateAuthority.SaveChanges();

            return new AddDelegatedAuthorityResponse {Success = true};
        }

        public async Task<AddDelegatedAuthorityResponse> UpdateDelegatedAuthority(GenericDelegatedAuthorityRequest request)
        {
            var oldData = delegateAuthority.All().SingleOrDefault(x => x.EmployeeID == request.EmployeeID);

            if (oldData == null)
            {
                return new AddDelegatedAuthorityResponse {Success = false, Message = "no such a user"};
            }

            oldData.EmployeeID = request.EmployeeID;
            oldData.CompanyEmployeeID = request.AuthorityEmployeeID;
                
            await delegateAuthority.SaveChangesAsync();

            return new AddDelegatedAuthorityResponse {Success = true};
        }

        public async Task<AddDelegatedAuthorityResponse> DeleteDelegatedAuthority(GenericDelegatedAuthorityRequest request)
        {
            var oldData = delegateAuthority.All().SingleOrDefaultAsync(x => x.EmployeeID == request.EmployeeID);

            if (oldData == null)
            {
                return new AddDelegatedAuthorityResponse { Success = false, Message = "no such a user" };
            }

            delegateAuthority.Delete(oldData);

            await delegateAuthority.SaveChangesAsync();

            return new AddDelegatedAuthorityResponse { Success = true };
        }
    }
}