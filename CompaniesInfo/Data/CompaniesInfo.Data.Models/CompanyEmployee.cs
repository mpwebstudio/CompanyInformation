namespace CompaniesInfo.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CompanyEmployee
    {
        [Key]
        public int ID { get; set; }

        public int CompanyID {get; set; }

        public int EmployeeID { get; set; }
    }
}