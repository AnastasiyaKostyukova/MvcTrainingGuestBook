using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Guestbook.Data;
using Guestbook.Helpers;
using Guestbook.Models;

namespace Guestbook.Controllers
{
  public class AccountController : Controller
  {
		private GuestbookContext _dbGuestbookContext = new GuestbookContext();
    // GET: Account
    public ActionResult LogOn()
    {
      return View();
    }

    public ActionResult ChangePassword()
    {
      return View();
    }

	  public ActionResult LogIn()
	  {
		  return View();
	  }

    [HttpPost]
    public ActionResult LogOn(LogOnModel logOn)
    {
      if (ModelState.IsValid)
      {
				var user = new User();
	      user.UserName = logOn.UserName;
	      user.Password = logOn.Password;
	      user.Email = logOn.Email.ToLower();
	      _dbGuestbookContext.Users.Add(user);
	      _dbGuestbookContext.SaveChanges();

	      AuthHelper.User = user.UserName;
        return RedirectToAction("Index", "Guestbook");
      }
      ModelState.AddModelError("", "Invalid form info");
      return View();
    }

	  [HttpPost]
	  public ActionResult LogIn(LogInModel logIn)
	  {
		  if (ModelState.IsValid)
		  {
			  var user = _dbGuestbookContext.Users.FirstOrDefault(m => m.Email == logIn.Email.ToLower());

			  if (user != null && user.Password == logIn.Password)
			  {
					AuthHelper.User = user.UserName;
					return RedirectToAction("Index", "Guestbook");
				}

				ModelState.AddModelError("", "Invalid email or password");
				return View();				
			}
			
			ModelState.AddModelError("", "Invalid form info");
			return View();
	  }

    [HttpPost]
    public ActionResult ChangePassword(ChangePasswordModel changedPass)
    {
      if (ModelState.IsValid)
      {
        return RedirectToAction("Index", "Guestbook");
      }
      ModelState.AddModelError("", "Invalid form info");
      return View();
    }

	  public ActionResult LogOut()
	  {
		  AuthHelper.User = null;
			return RedirectToAction("Index", "Guestbook");
		}
  }
}