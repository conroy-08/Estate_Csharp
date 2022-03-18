using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstateProject.Common;
using EstateProject.Controllers.Admin;
using EstateProject.Dao;
using EstateProject.Models;

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

        [HttpPost]
        public ActionResult changePassWord(PasswordModel pass)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new UserDao();
                    var user = dao.GetById(Session["UserName"].ToString());
                    if (Encrytor.MD5Hash(pass.oldPassword) == user.password)
                    {
                        dao.Update(user, pass.newPassword);
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Mật Khẩu cũ sai");
                        return View("ChangePassWord");
                    }
                }
                return View("ChangePassWord");
            }
            catch
            {
                return View();
            }

        }  
        public ActionResult EditUser()
        {
            return View();
        }


    }
}