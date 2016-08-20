using Guestbook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Guestbook.Data
{
  public class GuestbookContext : DbContext
  {
    public GuestbookContext() : base("GuestbookContext")
    {
    }

    public DbSet<GuestbookEntry> Entries { get; set; }
  }
}