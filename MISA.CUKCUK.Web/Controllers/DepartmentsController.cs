using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.AppliactionCore.Models;
using MISA.AppliactionCore.Interfaces;

namespace MISA.CUKCUK.Web.Controllers
{

    public class DepartmentsController : BaseEntitiesController<Department>
    {
        IBaseService<Department> _baseService;

        public DepartmentsController(IBaseService<Department> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
