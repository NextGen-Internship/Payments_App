using System;
using QArte.Persistance.PersistanceModels;
namespace QArte.Services.DTOs
{
	public class GalleryDTO
	{
		public int ID { get; set; }
		public List<PictureDTO> Pictures {get; set;} = new List<PictureDTO>();
	}
}

