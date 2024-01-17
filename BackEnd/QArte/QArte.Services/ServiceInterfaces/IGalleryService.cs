using System;
using QArte.Services.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using QArte.Persistance.Enums;

namespace QArte.Services.ServiceInterfaces
{
	public interface IGalleryService : ICRUDshared<GalleryDTO>
	{
		Task<GalleryDTO> GetGalleryByID(int id);
	}
}

