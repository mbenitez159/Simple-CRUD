using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using CRUD.API.Core;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
        protected IUnitOfWork UnitOfWork => _unitOfWork ??= HttpContext.RequestServices.GetService<IUnitOfWork>();

    }
}
