using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstateProject.Controllers.Admin;
namespace EstateProject.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult ListUser()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }
        
        public ActionResult ChangePassWord()
        {
            return View();
        }  
        public ActionResult EditUser()
        {
            return View();
        }


    }
}