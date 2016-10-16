namespace CompaniesInfo.Server.DataTransferModels.Employee
{
    using System.ComponentModel.DataAnnotations;
    using Common.Mapping;
    using Data.Models;

    public class CreateEmployeeRequest : IMapFrom<Employee>
    {
        [StringLength(250)]
        [Range(5, 250)]
        [Required]
        public string Fullname { get; set; }

        [StringLength(250)]
        public string PreferedName { get; set; }

        [Phone(ErrorMessage = "Invalid telephone number")]
        public string Telephone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
    }
}