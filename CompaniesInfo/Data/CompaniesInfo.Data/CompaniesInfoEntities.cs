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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(e => e.CompanyEmployees)
                .WithRequired(e => e.Company) 
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyEmployee>()
                .HasMany(e => e.DelegateAuthorities)
                .WithRequired(e => e.CompanyEmployee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.CompanyEmployees)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.CompanyEmployees)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.DelegateAuthority)
                .WithRequired(e => e.Employee);
        }
    }
}
