using System;
namespace QArte.Services.DTOs
{
	public class PageDTO
	{
		public int ID { get; set; }
		public string PageName { get;set; }
		public string Bio { get; set; }
		public string QRLink { get; set; }
		public int GalleryID { get; set; }
		public int UserID { get; set; }
	}
}

