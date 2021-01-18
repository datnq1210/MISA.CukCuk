using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AppliactionCore.Models
{
    public class Positional
    {
        /// <summary>
        /// id phòng ban
        /// </summary>
        public Guid PositionalId { get; set; }
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public string PositionalCode { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string PositionalName { get; set; }
    }
}
