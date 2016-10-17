namespace CompaniesInfo.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class DelegateAuthority
    {
        [Key]
        public int EmployeeID { get; set; }

        public int DelegatedEmployeeID { get; set; }

        public int OrderSeq { get; set; }
    }
}