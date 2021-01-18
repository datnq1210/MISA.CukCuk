using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AppliactionCore.Interfaces;
using MISA.AppliactionCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Web.Controllers
{
    public class EmployeesController : BaseEntitiesController<Employee>
    {
        IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService):base(employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{employeeCode}")]
        public Employee Get(string employeeCode)
        {
            return _employeeService.GetEmployeeByCode(employeeCode);
        }
    }
}
