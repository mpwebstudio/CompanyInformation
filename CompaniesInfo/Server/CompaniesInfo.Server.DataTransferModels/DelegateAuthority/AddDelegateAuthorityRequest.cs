namespace CompaniesInfo.Server.DataTransferModels.DelegateAuthority
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class AddDelegateAuthorityRequest : IMapFrom<DelegateAuthority>, IHaveCustomMapping
    {
        public int EmployeeID { get; set; }

        public int AuthorityEmployeeID { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<AddDelegateAuthorityRequest, DelegateAuthority>()
                .ForMember(t => t.CompanyEmployeeID, a => a.MapFrom(f => f.AuthorityEmployeeID));

        }
    }
}