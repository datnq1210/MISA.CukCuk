using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AppliactionCore.Interfaces;
using MISA.AppliactionCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Web.Controllers
{
    public class PositionalsController : BaseEntitiesController<Positional>
    {
        IBaseService<Positional> _baseService;

        public PositionalsController(IBaseService<Positional> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
