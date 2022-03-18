using EstateProject.Common;
using EstateProject.Dao;
using EstateProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstateProject.Controllers.Admin
{
    public class LoginController : Controller
    {
        public string USER_SESSION { get; private set; }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

    

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.login(model.UserName, Encrytor.MD5Hash(model.PassWord));
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.username;
                    userSession.UserId = user.id;

                    Session.Add(CommonConstants.USER_SESSION,userSession);

                    return RedirectToAction("Index", "Admin");

                }else if(result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");

                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");

                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");

                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }

            }
            return View("Index");
        }
    }
}