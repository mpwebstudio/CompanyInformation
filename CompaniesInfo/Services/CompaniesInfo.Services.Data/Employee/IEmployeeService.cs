namespace CompaniesInfo.Services.Data.Employee
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Server.Common;
    using Server.DataTransferModels.Employee;

    public interface IEmployeeService : IService
    {
        Task<EmployeeResponse> CreateEmployee(CreateEmployeeRequest request);

        Task<IList<GetEmployeesReponse>> GetEmployees(GetEmployeesRequest request);

        Task<IList<GetEmployeesReponse>> GetAllEmployees();

        Task<EmployeeResponse> UpdateEmployee(EmployeeResponse request);

        Task<DeleteEmployeeResponse> DeleteEmployee(DeleteEmployeeRequest request);
    }
}