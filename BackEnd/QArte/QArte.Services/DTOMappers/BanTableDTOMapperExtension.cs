using System;
using QArte.Persistance.PersistanceModels;
using QArte.Services.DTOs;

namespace QArte.Services.DTOMappers
{
	public static class BanTableDTOMapperExtension
    {

        public static BanTableDTO GetDTO(this BanTable banTable)
        {

            if (banTable is null)
            {
                throw new ApplicationException("This banTable is null");
            }



            return new BanTableDTO
            {
                ID = banTable.ID,
                BanID = banTable.BanID
            };

        }


        public static BanTable GetEntity(this BanTableDTO banTableDTO)
        {

            if (banTableDTO is null)
            {
                throw new ApplicationException("This banTableDTO is null");
            }

            return new BanTable
            {
                ID = banTableDTO.ID,
                BanID = banTableDTO.BanID
            };
        }

    }
}

