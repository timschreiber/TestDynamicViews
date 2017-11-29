using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDynamicViews.Data;

namespace TestDynamicViews.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {
            string viewName = "Index";

            if(id.HasValue)
                viewName = $"{viewName}{id}";

            return View(viewName, TestData.Employees);
        }
    }
}