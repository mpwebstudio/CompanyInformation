namespace CompaniesInfo.Server.Common.Mapping
{
    using AutoMapper;

    public interface IHaveCustomMapping
    {
        void CreateMappings(IConfiguration configuration);
    }
}