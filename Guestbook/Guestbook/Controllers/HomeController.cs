using Guestbook.Data;
using Guestbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guestbook.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      ViewBag.Message = "Hey, Nastya! It's your message =)";
      ViewBag.CurrentDate = DateTime.Now;
      //GuestbookContext guestbookContext = new GuestbookContext();
      //guestbookContext.Entries.Add(new GuestbookEntry { Name = "Lala",  DateAdded = DateTime.Now });
      //guestbookContext.SaveChanges();
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}