using System;
namespace QArte.Persistance.PersistanceModels
{
	public class Page
	{
		public int ID { get; set; }
		public string Bio { get; set; }
		public string QRLink { get; set; }
		public string PageName { get; set; }

		public int GalleryID { get; set; }
		public virtual Gallery Gallery { get; set; }

		public int UserID { get; set; }
		public virtual User User { get; set; }
	}
}

