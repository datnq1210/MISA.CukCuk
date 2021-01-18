using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AppliactionCore.Entities
{
    public class ServiceResult
    {
        public object Data { get; set; }
        /// <summary>
        /// Thông báo lỗi
        /// </summary>
        public string Messenger { get; set; }
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public int MISACode { get; set; }
    }
}
