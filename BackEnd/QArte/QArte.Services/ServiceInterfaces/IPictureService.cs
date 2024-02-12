using System;
using QArte.Services.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using QArte.Persistance.Enums;

namespace QArte.Services.ServiceInterfaces
{
	public interface IPictureService : ICRUDshared<PictureDTO>
	{
		Task<PictureDTO> GetPictureByID(int id);
		Task<IEnumerable<PictureDTO>> GetPicturesByGalleryID(int id);
	}
}

