namespace CompaniesInfo.Services.Data.Employee
{
    using System.Threading.Tasks;
    using Server.Common;
    using Server.DataTransferModels.Employee;

    public interface IEmployeeService : IService
    {
        Task<EmployeeResponse> CreateEmployee(CreateEmployeeRequest request);
    }
}