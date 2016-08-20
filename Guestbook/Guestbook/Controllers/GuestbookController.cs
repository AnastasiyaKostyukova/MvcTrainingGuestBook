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
      //bool hasPermission = User.Identity.Name == entry.Name;
      //ViewData["hasPermission"] = hasPermission;
      var r = _db.Entries.OrderByDescending(r1 => r1.DateAdded).Take(20);
      ViewBag.Entries = r.ToArray();
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
      var mostRecentEntries = (from entry in _db.Entries
                               orderby entry.DateAdded descending
                               select entry).Take(20);

      //var r = _db.Entries.OrderByDescending(r1 => r1.DateAdded).Take(20);
      ViewBag.Entries = mostRecentEntries.ToList();
      return View();
    }
  }
}