using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP_MB_MD.Web.Controllers
{
    public class LDOController : Controller
    {
        public IActionResult DashBord()
        {
            return View();
        }
    }
}
