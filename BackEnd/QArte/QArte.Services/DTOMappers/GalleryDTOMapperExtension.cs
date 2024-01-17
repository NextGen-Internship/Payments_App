using System;
using QArte.Persistance.PersistanceModels;
using QArte.Services.DTOs;

namespace QArte.Services.DTOMappers
{
	public static class GalleryDTOMapperExtension {

        public static GalleryDTO GetDTO(this Gallery gallery)
        {
            if (gallery is null)
            {
                throw new ApplicationException("This gallery is null");
            }


            List<PictureDTO> pictureDTOs = new List<PictureDTO>();

            foreach (Picture picture in gallery.Pictures)
            {
                pictureDTOs.Add(new PictureDTO { ID = picture.ID, PictureURL = picture.PictureURL, GalleryID = picture.GalleryID });
            }

            return new GalleryDTO
            {
                ID = gallery.ID,
                Pictures = pictureDTOs

            };

        }


        public static Gallery GetEntity(this GalleryDTO galleryDTO)
        {
            if (galleryDTO is null)
            {
                throw new ApplicationException("This galleryDTO is null");
            }


            List<Picture> pictures = new List<Picture>();

            foreach (PictureDTO pictureDTO in galleryDTO.Pictures)
            {
                pictures.Add(new Picture{ ID = pictureDTO.ID, PictureURL = pictureDTO.PictureURL, GalleryID = pictureDTO.GalleryID });
            }

            return new Gallery
            {
                ID = galleryDTO.ID,
                Pictures = pictures

            };

        }

    }
}

