using System;
using QArte.Persistance.Enums;
namespace QArte.Persistance.PersistanceModels
{
	public class Role
	{

        public Role()
        {
            Users = new HashSet<User>();
        }


        public int ID { get; set; }
        public ERoles ERole { get; set; }



        public virtual ICollection<User> Users { get; set; }  

    }
}


