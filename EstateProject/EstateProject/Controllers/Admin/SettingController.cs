using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstateProject.Controllers.Admin;
namespace EstateProject.Controllers.Admin
{
    public class SettingController : BaseController
    {
        // GET: Setting
        public ActionResult Setting()
        {
            return View();
        }
    }
}