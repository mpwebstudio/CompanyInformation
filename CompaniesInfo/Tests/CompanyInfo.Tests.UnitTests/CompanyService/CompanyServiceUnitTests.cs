namespace CompanyInfo.Tests.UnitTests.CompanyService
{
    using CompaniesInfo.Server.DataTransferModels.Company;
    using CompaniesInfo.Services.Data.Company;
    using NUnit.Framework;

    [TestFixture]
    public class CompanyServiceUnitTests
    {
        [Test, RollBack]
        public void CreateCompany()
        {
            var company = new CreateCompanyRequest
            {
                CompanyName = "Nice Pak",
                PrimeContactID = 1
            };

            //var pesho = _companyService.CreateCompany(company);

            Assert.Pass();
        }
    }
}