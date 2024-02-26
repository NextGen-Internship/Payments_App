using System;
namespace QArte.Persistance.PersistanceModels
{
	public class Picture
	{
		public int ID { get; set; }
		public string PictureURL { get; set; }


		public int GalleryID { get; set; }
		public virtual Gallery Gallery { get; set; }
	}
}

