using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AppliactionCore.Models
{   
    /// <summary>
    /// Attribute xác định thông tin bắt buộc phải nhập
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Required: Attribute
    {   
        public string propertyName;
        public string errorMsg;
        public Required(string propertyName, string errorMsg)
        {
            this.propertyName = propertyName;
            this.errorMsg = errorMsg;
        }
    }
    /// <summary>
    /// Attribute xác định thông tin bị trùng
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : Attribute
    {
        public string propertyName;
        public string errorMsg;
        public CheckDuplicate(string propertyName, string errorMsg)
        {
            this.propertyName = propertyName;
            this.errorMsg = errorMsg;
        }

    }
    /// <summary>
    /// Attribute xác định độ dài tối ta
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        public string propertyName;
        public string errorMsg;
        public int Length;
        public MaxLength(string propertyName,int length, string errorMsg)
        {
            this.propertyName = propertyName;
            this.errorMsg = errorMsg;
            this.Length = length;
        }
    }
    class BaseEntity
    {
    }
}
