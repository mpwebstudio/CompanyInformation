namespace CompaniesInfo.Data.Models
{
    using System.Collections.Generic;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Companies = new HashSet<Company>();
            CompanyEmployees = new HashSet<CompanyEmployee>();
        }

        public int ID { get; set; }

        public string Fullname { get; set; }

        public string PreferedName { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public bool IsLive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Company> Companies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyEmployee> CompanyEmployees { get; set; }

        public virtual DelegateAuthority DelegateAuthority { get; set; }
    }
}