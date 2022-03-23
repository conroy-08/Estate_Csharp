using EstateProject.Common;
using EstateProject.Controllers.Admin;
using EstateProject.Dao;
using EstateProject.Dto;
using EstateProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EstateProject.Controllers
{
    public class BuildingController : Controller
    {
        EstateDbContext db = new EstateDbContext();

       
        [HttpGet]
        public ActionResult ListBuilding(BuildingSearchDto building)
        {


            var dao = new BuildingDao();
            var data = dao.findAll(building);
           
            return View(data);


        }

        public ActionResult MyListBuilding()
        {
            return View();
        }

        public ActionResult DetailBuilding()
        {
            return View();
        }

        public ActionResult EditBuilding(int? id )
        {
              
                if (id == null)
                {
                   return View(new BuildingDto());
                }
                var building = new BuildingDao().findById(id);
                if (building == null)
                {
                        return HttpNotFound();
                }
                BuildingDto buildingDto = BuildingConverter.converterToDto(building);

                return View(buildingDto);
           
        }

   


        [HttpPost]
        public JsonResult Insert(BuildingDto building )
        {
            try
            {
                var dao = new BuildingDao();
                dao.save(building);

                return Json(new { status = true });
            }
            catch (Exception e)
            {
                return Json(new { code = 500, mes = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPut]
        public JsonResult Edit(BuildingDto building )
        {
            try
            {
                var dao = new BuildingDao();
                
                dao.Update(building.id, building);
                
                return Json(new { status = true , id = building.id });
                
            }
            catch (Exception e)
            {
                return Json(new { code = 500, mes = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpDelete]
        public JsonResult Delete(List<int> ids)
        {
            try
            {
                var dao = new BuildingDao();
                dao.delete(ids);

                return Json(new { status = true });
            }
            catch (Exception e)
            {
                return Json(new { code = 500, mes = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public JsonResult ImageUpload(BuildingDto model)
        {

            try
            {
                var file = model.imageFile;

                if (file != null)
                {
                    /*        var fileName = Path.GetFileName(file.FileName);
                            var extention = Path.GetExtension(file.FileName);
                            var fileNameWithoutExtention = Path.GetFileNameWithoutExtension(file.FileName);*/

                    file.SaveAs(Server.MapPath("~/Assets/Upload/Building/" + file.FileName));

                }

                return Json(file.FileName, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, mes = e.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult UploadFiles()
        {
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            string[] path = new string[files.Count];

            for(var i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                string rootPath = "~/Assets/Upload/Building/" + file.FileName;
                path[i] = rootPath.Substring(1);
                file.SaveAs(Server.MapPath(rootPath));

            }
            return Json(path, JsonRequestBehavior.AllowGet);
        }


    }
}