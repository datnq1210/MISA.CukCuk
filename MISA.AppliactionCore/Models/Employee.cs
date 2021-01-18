using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AppliactionCore.Models
{
    public class Employee
    {
        
        public Guid EmployeeId { get; set; }
        [CheckDuplicate("Mã nhân viên","")]
        [Required("Mã nhân viên","")]
        [MaxLength("Mã khách hàng",20,"")]
        public string EmployeeCode { get; set; }
        [Required("Họ và tên","")]
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }

        [CheckDuplicate("Số CMTND", "")]
        [Required("Số CMTND","")]
        public string IdentityNumber { get; set; }
        public DateTime IdentityDate { get; set; }
        public string IdentityPlace { get; set; }

        [CheckDuplicate("Email", "")]
        [Required("Email","")]
        public string Email { get; set; }
        [CheckDuplicate("Số điện thoại", "")]
        [Required("Số điện thoại","")]
        public string PhoneNumber { get; set; }
        public Guid PositionalId { get; set; }
        public string PositionalCode { get; set; }
        public string PositionalName { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        [CheckDuplicate("Mã số thuế cá nhân", "")]
        public string PersonalTaxCode { get; set; }
        public int Salary { get; set; }
        public DateTime JoinDate { get; set; }
        public string WorkStatusName { get; set; }
    }
}
