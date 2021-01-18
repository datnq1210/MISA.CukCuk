using MISA.AppliactionCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AppliactionCore.Interfaces
{
    public interface IEmployeeService: IBaseService<Employee>
    {
        Employee GetEmployeeByCode(string employeeCode);
    }
}
