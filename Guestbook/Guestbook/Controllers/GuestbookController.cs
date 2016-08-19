using Guestbook.Models;
using Guestbook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guestbook.Controllers
{
  public class GuestbookController : Controller
  {
    bool hasPermission = true;

    private GuestbookContext _db = new GuestbookContext();
    public ActionResult Create()
    {
      return View();
    }
    public ViewResult Show(int id)
    {
      var entry = _db.Entries.Find(id);
      ViewBag.HasPermission = hasPermission;
      return View(entry);
    }

    [HttpPost]
    public ActionResult Create(GuestbookEntry entry)
    {
      entry.DateAdded = DateTime.Now;
      _db.Entries.Add(entry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Index()
    {
      var mostRecentEntries = _db.Entries.OrderByDescending(r1 => r1.DateAdded).Take(20);
      return View(mostRecentEntries.ToList());
    }
  }
}