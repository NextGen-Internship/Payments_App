using System;
using QArte.Persistance.PersistanceModels;
using QArte.Services.DTOs;

namespace QArte.Services.DTOMappers
{
	public static class PictureDTOMapperExtension
    {
        public static PictureDTO GetDTO(this Picture picture)
        {
            if (picture is null)
            {
                throw new ApplicationException("This picture is null");
            }

            return new PictureDTO
            {
                ID = picture.ID,
                PictureURL = picture.PictureURL,
                GalleryID = picture.GalleryID,
            };

        }

        public static Picture GetEntity(this PictureDTO pictureDTO)
        {
            if (pictureDTO is null)
            {
                throw new ApplicationException("This pictureDTO is null");
            }

            return new Picture
            {
                ID = pictureDTO.ID,
                PictureURL = pictureDTO.PictureURL,
                GalleryID = pictureDTO.GalleryID
                
            };

        }
    }
}

