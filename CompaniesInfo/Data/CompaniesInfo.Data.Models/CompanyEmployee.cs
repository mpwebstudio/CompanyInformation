namespace CompaniesInfo.Data.Models
{
    using System.Collections.Generic;

    public partial class CompanyEmployee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompanyEmployee()
        {
            DelegateAuthorities = new HashSet<DelegateAuthority>();
        }

        public int ID { get; set; }

        public int CompanyID { get; set; }

        public int EmployeeID { get; set; }

        public virtual Company Company { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DelegateAuthority> DelegateAuthorities { get; set; }
    }
}