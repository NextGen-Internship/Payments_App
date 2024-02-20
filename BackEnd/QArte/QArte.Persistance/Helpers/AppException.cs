using System;
using System.Globalization;

namespace QArte.Persistance.Helpers
{
	public class AppException : ApplicationException
	{
		public AppException():base()
		{
		}

		public AppException(string message) : base(message) { }

		public AppException(string message, params object[] args):
			base(String.Format(CultureInfo.CurrentCulture, message, args))
		{

		}
	}
}

