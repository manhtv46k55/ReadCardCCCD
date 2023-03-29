using Newtonsoft.Json;
using ReadCard.Data;
using ReadCard.Data.Entities;
using ReadCard.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ReadCard.Controllers
{
    public class HomeController : Controller
    {
        CCCDEntities1 cnn = new CCCDEntities1();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCard()
        {
            AppRepository _appRepository = new AppRepository();
            ViewBag.ListCard = _appRepository.GetCard().ToList();
            return PartialView("_ListCard");
        }

        public int DeleteItem(int iItemID)
        {
            int iResult = 0;
            CCCD cc = cnn.CCCDs.Where(x => x.ID == iItemID).FirstOrDefault();
            if (cc != null)
            {
                cnn.CCCDs.Remove(cc);
                cnn.SaveChanges();
                iResult = 1;
            }
            else
            {
                iResult = 0;
            }
            return iResult;
        }

        public int DeleteAllItem()
        {
            int iResult = 0;
            var kq = cnn.CCCDs.ToList();
            if (kq != null)
            {
                cnn.CCCDs.RemoveRange(kq);
                cnn.SaveChanges();
                iResult = 1;
            }
            else
            {
                iResult = 0;
            }
            return iResult;
        }

    }
}
