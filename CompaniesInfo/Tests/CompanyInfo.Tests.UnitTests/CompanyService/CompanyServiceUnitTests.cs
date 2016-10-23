namespace CompanyInfo.Tests.UnitTests.CompanyService
{
    using CompaniesInfo.Data.Common.Repositories;
    using CompaniesInfo.Data.Models;
    using CompaniesInfo.Server.DataTransferModels.Company;
    using CompaniesInfo.Services.Data.Company;
    using CompaniesInfo.Services.Data.CompanyEmployee;
    using CompaniesInfo.Services.Data.Employee;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CompanyServiceUnitTests
    {
        [Test]
        public void CreateCompanyService()
        {
            var repository = new Mock<IRepository<Company>>();
            var empService = new Mock<IEmployeeService>();
            var compEmplSer = new Mock<ICompanyEmployeeService>();

            var service = new CompanyService(repository.Object, empService.Object, compEmplSer.Object);

            Assert.That(service, Is.Not.Null);
        }

        [Test]
        public void CreateCompany()
        {
            var repository = new Mock<IRepository<Company>>();
            var empService = new Mock<IEmployeeService>();
            var compEmplSer = new Mock<ICompanyEmployeeService>();
            var compService = new Mock<ICompanyService>();

            var service = new CompanyService(repository.Object, empService.Object, compEmplSer.Object);
            var company = new CreateCompanyRequest {CompanyName = "Test", PrimeContactID = 2, IsLive = true};
            var companyResponse = new CompanyResponse { CompanyName = "Test", IsLive = true};

            compService.Setup(r => r.CreateCompany(company)).ReturnsAsync(companyResponse);

            var result = service.CreateCompany(company);

            Assert.That(result, Is.Not.Null);
        }
    }
}