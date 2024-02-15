using System;
using QArte.Persistance.PersistanceModels;
using QArte.Services.DTOs;

namespace QArte.Services.DTOMappers
{
	public static class PageDTOMapperExtension
    {
        public static PageDTO GetDTO(this Page page)
        {
            if (page is null)
            {
                throw new ApplicationException("This page is null");
            }


            return new PageDTO
            {
                ID = page.ID,
                Bio = page.Bio,
                PageName = page.PageName,
                QRLink = page.QRLink,
                GalleryID = page.GalleryID,
                UserID = page.UserID

            };

        }


        public static Page GetEntity(this PageDTO pageDTO)
        {
            if (pageDTO is null)
            {
                throw new ApplicationException("This pageDTO is null");
            }


            return new Page
            {
                ID = pageDTO.ID,
                Bio = pageDTO.Bio,
                PageName = pageDTO.PageName,
                QRLink = pageDTO.QRLink,
                GalleryID = pageDTO.GalleryID,
                UserID = pageDTO.UserID

            };

        }

    }
}

