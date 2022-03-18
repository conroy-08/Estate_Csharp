using EstateProject.Controllers.Admin;
using EstateProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EstateProject.Controllers
{
    public class BuildingController : BaseController
    {
        EstateDbContext db = new EstateDbContext();

        public ActionResult ListBuilding()
        {
            return View();
        }


        [HttpGet]
        public JsonResult getAll()
        {
            try
            {
                var data = db.buildings.ToList();
                List<Array> temp = new List<Array>();
                data.ForEach(n =>
                {
                    String Id = n.id.ToString();
                    DateTime Create = Convert.ToDateTime(n.createddate);
                    String CreatedDate = Create.ToString("yyyy-MM-dd");
                    String Name = n.name;
                    String Address = n.street + ", " + n.ward + ", " + n.district;
                    String FloorArea = n.floorarea.ToString();
                    String RentPrice = n.rentprice.ToString();
                    String ServiceCost = n.servicefee;
                    String BrokerageCost = n.brokeragetee.ToString();            
                    String[] buildings = { Id,CreatedDate, Name , Address , FloorArea , RentPrice, ServiceCost , BrokerageCost };
                    temp.Add(buildings);
                });
                return Json(new { data = temp }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult MyListBuilding()
        {
            return View();
        }

        public ActionResult DetailBuilding()
        {
            return View();
        }

        public ActionResult EditBuilding()
        {
            return View();
        }

    }
}