namespace CompanyInfo.Tests.UnitTests.RouteTests
{
    using System.Net.Http;
    using CompaniesInfo.Server.Api.Controllers;
    using MyTested.WebApi;
    using NUnit.Framework;

    [TestFixture]
    public class CompanyRouteTests
    {
        [Test]
        public void GetCompany()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/company/getCompany/5")
                .WithHttpMethod(HttpMethod.Get)
                .To<CompanyController>(c => c.GetCompany(5))
                .ToValidModelState();
        }
    }
}