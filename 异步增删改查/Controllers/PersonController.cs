using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestIService;
using TestService;

namespace 异步增删改查.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public async Task<ActionResult> Index()
        {
            IPersonService personService = new PersonService();
           var data=   personService.GetaLL();

            return View(data);
        }
        [HttpGet]
        public  async Task<ActionResult>AddNew()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddNew(Models.PersonAddNewModel model)
        {
            IPersonService personService = new PersonService();
            await personService.AddAsync(model.Name, model.Age);
            return Content("ok");
        }
    }
}