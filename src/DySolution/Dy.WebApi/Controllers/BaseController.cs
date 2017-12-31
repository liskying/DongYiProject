using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dy.WebApi.Controllers
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    [Produces("application/json", "text/json")]
    public abstract class BaseController : Controller
    {
    }
}