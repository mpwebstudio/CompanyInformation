namespace CompaniesInfo.Data.Models
{
    using System.Collections.Generic;

    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            CompanyEmployees = new HashSet<CompanyEmployee>();
        }

        public int ID { get; set; }

        public string CompanyName { get; set; }

        public bool IsLive { get; set; } = true;

        public int EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyEmployee> CompanyEmployees { get; set; }
    }
}