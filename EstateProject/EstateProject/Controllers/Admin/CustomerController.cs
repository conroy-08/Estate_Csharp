using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstateProject.Controllers.Admin;
namespace EstateProject.Controllers.Admin
{
    public class CustomerController : BaseController
    {
        // GET: Customer
        public ActionResult ListCustomers()
        {
            return View();
        }

        public ActionResult EditCustomers()
        {
            return View();
        }
    }
}