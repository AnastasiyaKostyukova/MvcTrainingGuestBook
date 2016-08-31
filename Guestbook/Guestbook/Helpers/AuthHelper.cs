using System.Web;

namespace Guestbook.Helpers
{
	public class AuthHelper
	{
		private const string UserKey = "user";

		public static string User
		{
			get
			{
				return HttpContext.Current.Session[UserKey]?.ToString();
			}
			set
			{
				HttpContext.Current.Session[UserKey] = value;
			}
		}

		public static bool IsAuthorized
		{
			get
			{
				return HttpContext.Current.Session[UserKey] != null;
			}
		}
	}
}