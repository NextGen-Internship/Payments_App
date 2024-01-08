using System;
using QArte.Persistance.Enums;
namespace QArte.Persistance.PersistanceModels
{
	public class Role
	{

        public Role()
        {
            Artists = new HashSet<Artist>();
            Admins = new HashSet<Admin>();
        }


        public int ID { get; set; }
        public ERoles ERole { get; set; }



        public virtual ICollection<Artist> Artists { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }

    }
}


