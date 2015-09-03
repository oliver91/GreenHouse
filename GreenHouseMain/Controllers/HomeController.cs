using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenHouseMain.Models;

namespace GreenHouseMain.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new Database1Entities();
            var items = from i in db.Rooms
                join fi in db.Reservations on i.RoomId equals fi.RoomId
                where fi.UserId == 1
                select i;
            var r = new Room();
            r.Number = items.ToList()[0].Number;
            var c = new List<Room>();
            c.Add(r);
            return View(c);
        }
    }
}