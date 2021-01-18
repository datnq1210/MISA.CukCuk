using MISA.AppliactionCore.Entities;
using MISA.AppliactionCore.Enums;
using MISA.AppliactionCore.Interfaces;
using MISA.AppliactionCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.AppliactionCore.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        IBaseRepository<T> _baseRepository;
        protected ServiceResult _serviceResult;
        string tableName;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
            tableName = typeof(T).Name;
        }
        public IEnumerable<T> GetData()
        {
            return _baseRepository.GetData($"Proc_GetAll{tableName}");
        }

        public ServiceResult Insert(T entity)
        {
            ValidateObj(entity);
            if (_serviceResult.MISACode == (int)MISACode.badRequest)
                return _serviceResult;
            string sqlProc = $"Proc_Insert{tableName}";
            var res = _baseRepository.ExcuteQuery(entity, sqlProc);
            if (res > 0)
            {
                _serviceResult.MISACode = (int)MISACode.success;
                _serviceResult.Messenger = "Thêm mới dữ liệu thành công";
            }
            return _serviceResult;
        }

        public ServiceResult Update(T entity)
        {
            string sqlProc = $"Proc_Update{tableName}";
            var res = _baseRepository.ExcuteQuery(entity, sqlProc);
            if (res > 0)
            {
                _serviceResult.MISACode = (int)MISACode.success;
                _serviceResult.Messenger = "Sửa dữ liệu thành công";
            }
            return _serviceResult;
        }

        public ServiceResult Delete(T entity)
        {
            string sqlProc = $"Proc_Delete{tableName}";
            var res = _baseRepository.ExcuteQuery(entity, sqlProc);
            if (res > 0)
            {
                _serviceResult.MISACode = (int)MISACode.success;
                _serviceResult.Messenger = "Xóa dữ liệu thành công";
            }
            return _serviceResult;
        }

        public void ValidateObj(T entity)
        {   
            //Lấy các property
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                var propertyName = property.Name;
                //Nếu có attribute [Required] thì bắt buộc phải nhập
                if (property.IsDefined(typeof(Required), true) && (propertyValue == null || propertyValue.ToString().Trim() == string.Empty))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as Required).propertyName;
                        _serviceResult.Messenger += $"{propertyText} không được phép để trống. ";
                        _serviceResult.MISACode = (int)MISACode.badRequest;
                    }
                }
                else if (property.IsDefined(typeof(CheckDuplicate), true))
                {
                    var dupliacteAttribute = property.GetCustomAttributes(typeof(CheckDuplicate), true).FirstOrDefault();
                    if (dupliacteAttribute != null)
                    {
                        var propertyText = (dupliacteAttribute as CheckDuplicate).propertyName;
                        var sql = $"SELECT {propertyName} FROM {tableName} WHERE {propertyName} = '{propertyValue}'";
                        var obj = _baseRepository.GetData(sql).FirstOrDefault();
                        if (obj != null)
                        {
                            _serviceResult.Messenger += $"{propertyText} đã tồn tại trên hệ thống! ";
                            _serviceResult.MISACode = (int)MISACode.badRequest;
                        }
                    }
                }

                else if (property.IsDefined(typeof(MaxLength), true))
                {
                    var maxLengthAttribute = property.GetCustomAttributes(typeof(MaxLength), true).FirstOrDefault();
                    if (maxLengthAttribute != null)
                    {
                        var propertyText = (maxLengthAttribute as MaxLength).propertyName;
                        var length = (maxLengthAttribute as MaxLength).Length;
                        if (propertyValue.ToString().Trim().Length > length)
                        {
                            _serviceResult.Messenger += $"{propertyText} không được vượt quá {length} kí tự";
                            _serviceResult.MISACode = (int)MISACode.badRequest;
                        }
                        
                    }
                }
               
            }
        }
    }
}
