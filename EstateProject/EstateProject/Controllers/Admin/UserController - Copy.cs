using System;
using System.Collections.Generic;
using System.IO;
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
            if(Session["UserName"] != null)
            {
                var dao = new UserDao();
                var user = dao.GetById(Session["UserName"].ToString());
                return View(user);
            }
            return RedirectToAction("Index","Login");
        }

        [HttpPost]
        public ActionResult profile(user users)
        {
            if (Session["UserName"] != null)
            {
                var path = "/Assets/Upload/Avartar/";
                var dao = new UserDao();
                var user = dao.GetById(Session["UserName"].ToString());
              
                Session["FullName"] = user.fullname;
                //Use Namespace called :  System.IO  
                string FileName = Path.GetFileNameWithoutExtension(users.imageFile.FileName);                           
                //To Get File Extension  
                string FileExtension = Path.GetExtension(users.imageFile.FileName);
                //Add Current Date To Attached File Name  
                FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

                users.image = path + FileName;
                users.imageFile.SaveAs(users.image);

                dao.UpdateProfile(user,users.fullname,users.email,users.phone,users.image);
                return View(user);
            }
            return RedirectToAction("Index", "Login");
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