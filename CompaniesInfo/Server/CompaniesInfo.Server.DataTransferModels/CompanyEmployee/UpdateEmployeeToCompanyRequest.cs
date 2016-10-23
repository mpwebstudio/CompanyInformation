namespace CompaniesInfo.Server.DataTransferModels.CompanyEmployee
{
    using System.Collections.Generic;

    public class UpdateEmployeeToCompanyRequest
    {
        public int EmployeeID { get; set; }

        public List<int> CompanyID { get; set; }
    }
}