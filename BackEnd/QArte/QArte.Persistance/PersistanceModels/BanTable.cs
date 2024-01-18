using System;
namespace QArte.Persistance.PersistanceModels
{
	public class BanTable
	{
		public int ID { get; set; }
		public int BanID { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

