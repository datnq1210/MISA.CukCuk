using MISA.AppliactionCore.Entities;
using MISA.AppliactionCore.Enums;
using MISA.AppliactionCore.Interfaces;
using MISA.AppliactionCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AppliactionCore.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) :base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Employee GetEmployeeByCode(string employeeCode)
        {
            return _employeeRepository.GetEmployeeByCode(employeeCode);
        }
    }
}
