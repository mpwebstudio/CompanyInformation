namespace CompaniesInfo.Services.Data.Employee
{
    using System.Threading.Tasks;
    using Server.Common;
    using Server.DataTransferModels;
    using Server.DataTransferModels.Employee;

    public interface IEmployeeService : IService
    {
        Task<GenericResponse> CreateEmployee(CreateEmployeeRequest request);

        Task<GenericResponse> GetEmployees(GetEmployeesRequest request);

        Task<GenericResponse> GetAllEmployees();

        Task<GenericResponse> UpdateEmployee(EmployeeResponse request);

        Task<GenericResponse> DeleteEmployee(DeleteEmployeeRequest request);
    }
}