namespace CompaniesInfo.Data
{
    using Models;
    using System.Data.Entity;

    public class CompaniesInfoEntities : DbContext
    {
        public CompaniesInfoEntities()
            :base("name=CompaniesInfo")
        {
        }

        public virtual IDbSet<Company> Companies { get; set; }

        public virtual IDbSet<Employee> Employees { get; set; }

        public virtual IDbSet<CompanyEmployee> CompanyEmployees { get; set; }

        public virtual IDbSet<DelegateAuthority> DelegateAuthorities { get; set; }

        public static CompaniesInfoEntities Create()
        {
            return new CompaniesInfoEntities();
        }
    }
}
