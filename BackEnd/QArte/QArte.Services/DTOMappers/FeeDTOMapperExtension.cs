using System;
using QArte.Persistance.PersistanceModels;
using QArte.Services.DTOs;

namespace QArte.Services.DTOMappers
{
	public static class FeeDTOMapperExtension
    {

        public static FeeDTO GetDTO(this Fee fee)
        {
            if (fee is null)
            {
                throw new ApplicationException("This Fee is null");

            }

            return new FeeDTO
            {
                ID = fee.ID,
                Amount = fee.Amount,
                Currency = fee.Currency,
                ExchangeRate = fee.ExchangeRate
            };
        }

        public static Fee GetEntity(this FeeDTO feeDTO)
        {
            if (feeDTO is null)
            {
                throw new ApplicationException("This FeeDTO is null");

            }

            return new Fee
            {
                ID = feeDTO.ID,
                Amount = feeDTO.Amount,
                Currency = feeDTO.Currency,
                ExchangeRate = feeDTO.ExchangeRate
            };
        }

    }
}

