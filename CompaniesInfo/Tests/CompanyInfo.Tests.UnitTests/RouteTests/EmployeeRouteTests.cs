namespace CompanyInfo.Tests.UnitTests.RouteTests
{
    using System.Net.Http;
    using CompaniesInfo.Server.Api.Controllers;
    using CompaniesInfo.Server.DataTransferModels.Employee;
    using MyTested.WebApi;
    using NUnit.Framework;

    [TestFixture]
    public class EmployeeRouteTests
    {
        [Test]
        public void GetEmployeeById()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/employee/getSingleEmployee/1")
                .WithHttpMethod(HttpMethod.Get)
                .To<EmployeeController>(c => c.GetSingleEmployee(1))
                .ToValidModelState();
        }

        [Test]
        public void CreateEmployee()
        {
            var request = new CreateEmployeeRequest
            {
                Fullname = "TesteUser",
                PreferedName = "User",
                Telephone = "07987979",
                Email = "test@test.com",
                IsLive = true
            };

            MyWebApi
                .Routes()
                .ShouldMap("api/employee/createemployee")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{""Fullname"":""TesteUser"",""PreferedName"":""User"", ""Telephone"":""07987979"",""Email"":""test@test.com"", ""isLive"":true}")
                .To<EmployeeController>(c => c.CreateEmployee(request))
                .ToInvalidModelState();
        }
    }
}