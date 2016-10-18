namespace CompaniesInfo.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class DelegateAuthority
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }

        public int CompanyEmployeeID { get; set; }

        public int OrderSeq { get; set; }

        public virtual CompanyEmployee CompanyEmployee { get; set; }

        public virtual Employee Employee { get; set; }
    }
}