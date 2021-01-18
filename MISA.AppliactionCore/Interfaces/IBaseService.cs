using MISA.AppliactionCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AppliactionCore.Interfaces
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns>Dữ liệu lấy được</returns>
        IEnumerable<T> GetData();

        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="entity">một đối tượng</param>
        /// <returns>Số bản ghi được thêm</returns>
        /// 
        ServiceResult Insert(T entity);
        /// <summary>
        /// Sửa một bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi được sửa</returns>
        ServiceResult Update(T entity);

        /// <summary>
        /// Xóa một bản ghi
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Số bản ghi bị xóa</returns>
        ServiceResult Delete(T entity);
    }
}
