﻿namespace CompaniesInfo.Server.DataTransferModels.Employee
{
    public class DeleteEmployeeRequest
    {
        public int EmployeeID { get; set; }

        public int CompanyID { get; set; }
    }
}