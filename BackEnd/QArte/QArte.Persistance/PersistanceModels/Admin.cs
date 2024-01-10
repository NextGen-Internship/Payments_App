using System;
namespace QArte.Persistance.PersistanceModels
{
	public class Admin:User
	{

		public int RoleID { get; set; }
		public virtual Role Role { get;set; }
	}
}

