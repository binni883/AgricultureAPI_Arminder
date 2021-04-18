using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureAPI_Arminder.Controllers
{
    public class AgricultureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
