using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_TPL.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<ActionResult> Index()
        {
            return View();
        }
        // GET: Default
      
    }
}