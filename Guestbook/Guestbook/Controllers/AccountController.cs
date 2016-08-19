using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Guestbook.Models;

namespace Guestbook.Controllers
{
  public class AccountController : Controller
  {
    // GET: Account
    public ActionResult LogOn()
    {
      return View();
    }

    [HttpPost]
    public ActionResult LogOn(LogOnModel logOn)
    {
      if (ModelState.IsValid)
      {
        return RedirectToAction("Index", "Guestbook");
      }
      ModelState.AddModelError("", "Invalid form info");
      return View();
    }
  }
}