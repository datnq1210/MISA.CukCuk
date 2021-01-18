using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AppliactionCore.Interfaces
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetData(string SqlQuery);
        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int ExcuteQuery(T entity, string SqlProc);
       
    }
}
