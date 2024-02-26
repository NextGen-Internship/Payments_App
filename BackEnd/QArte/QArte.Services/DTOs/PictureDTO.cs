using System;
using Microsoft.AspNetCore.Http;

namespace QArte.Services.DTOs
{
	public class PictureDTO
	{
		public int ID { get; set; }
		public string PictureURL { get; set; }
		public int GalleryID { get; set; }
		public IFormFile file { get; set; }
		public bool isImage { get; set; }
	}
}

