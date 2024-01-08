using System;
namespace QArte.Persistance.PersistanceModels
{
	public class Artist : User
	{
        public Artist()
        {
            Pages = new HashSet<Page>();
        }

		public int RoleID { get; set; }
		public virtual Role Role { get; set; }

        public int BanID { get; set; }
        public virtual BanTable Ban { get; set; }

        public virtual ICollection<Page> Pages{ get; set; }

        public int BankAccountID { get; set; }
        public virtual BankAccount BankAccount { get; set; }
    }
}

