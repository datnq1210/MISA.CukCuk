﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AppliactionCore.Models
{
    public class Department
    {
        /// <summary>
        /// id phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public string DepartmentCode { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
