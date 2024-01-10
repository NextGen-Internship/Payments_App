using System;
namespace QArte.Persistance.PersistanceModels
{
	public class Gallery
	{
		public Gallery()
		{
			Pictures = new HashSet<Picture>();
		}

		public int ID { get; set; }

		public virtual ICollection<Picture> Pictures { get; set; }
	}
}

