using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.AppliactionCore.Interfaces;
using MISA.AppliactionCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MISA.Infrastructure
{
    public class EmployeeRepository: BaseRepository<Employee>, IEmployeeRepository
    {
        IConfiguration _configuaration;

        public EmployeeRepository(IConfiguration configuaration):base(configuaration)
        {
            _configuaration = configuaration;
        }

        public Employee GetEmployeeByCode(string employeeCode)
        {
            var paremeters = new DynamicParameters();
            paremeters.Add("@EmployeeCode", employeeCode);
            return dbConnection.Query<Employee>($"Proc_GetEmployeeByCode", paremeters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
    }
}
