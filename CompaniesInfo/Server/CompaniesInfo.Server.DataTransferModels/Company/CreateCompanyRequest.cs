﻿namespace CompaniesInfo.Server.DataTransferModels.Company
{
    public class CreateCompanyRequest
    {
        public string CompanyName { get; set; }

        public int PrimeContactID { get; set; }
    }
}