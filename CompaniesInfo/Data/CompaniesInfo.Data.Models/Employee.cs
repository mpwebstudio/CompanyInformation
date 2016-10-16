namespace CompaniesInfo.Data.Models
{
    public class Employee
    {
        public int ID { get; set; }

        public string Fullname { get; set; }

        public string PreferedName { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public bool IsLive { get; set; }
    }
}