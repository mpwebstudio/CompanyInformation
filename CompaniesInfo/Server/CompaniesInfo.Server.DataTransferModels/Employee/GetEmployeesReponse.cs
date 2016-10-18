﻿namespace CompaniesInfo.Server.DataTransferModels.Employee
{
    using Common.Mapping;
    using Data.Models;

    public class GetEmployeesReponse : IMapFrom<Employee>
    {
        public int ID { get; set; }

        public string Fullname { get; set; }

        public string PreferedName { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }
    }
}