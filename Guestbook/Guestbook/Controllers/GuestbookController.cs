using Guestbook.Models;
using Guestbook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Guestbook.Helpers;

namespace Guestbook.Controllers
{
  public class GuestbookController : Controller
  {
    bool hasPermission = true;

    private GuestbookContext _db = new GuestbookContext();
    public ActionResult Create()
    {
			var model = new GuestbookEntry();
	    model.Name = AuthHelper.User;

      return View(model);
    }
    public ViewResult Show(int id)
    {
      var entry = _db.Entries.Find(id);

	    var userName = AuthHelper.User;
			ViewBag.HasPermission = AuthHelper.IsAuthorized;

			return View(entry);
    }

	  public ActionResult CommentSummary()
	  {
		  //var entries1 = _db.Entries.OrderByDescending(r => r.Name).Count();
		  var entries = from entry in _db.Entries group entry 
										by entry.Name into groupedByName
										orderby groupedByName.Count() 
										descending
										select new CommentSummaryModel
										{
											NumberOfComments = groupedByName.Count(),
											UserName = groupedByName.Key
										};
			return View(entries.ToList());
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
    //  var mostRecentEntries = 
				//_db.Entries`

			/* var mostRecentEntries = (from entry in _db.Entries
			 * orderby entry.DateAdded descending 
			 * select entry).Take(20);
			 * ViewBag.Entries = mostRecentEntries.ToList();*/

	    var mostRecentEntries = new List<GuestbookEntry>();

	    if (AuthHelper.IsAuthorized)
	    {
		    mostRecentEntries = _db.Entries
			    .Where(x => x.Name == AuthHelper.User)
			    .OrderByDescending(r1 => r1.DateAdded)
			    .Take(20)
			    .ToList();
	    }
	    else
	    {
				mostRecentEntries = _db.Entries
					.OrderByDescending(r1 => r1.DateAdded)
					.Take(20)
					.ToList();
			}
			
      return View(mostRecentEntries);
    }
  }
}
 