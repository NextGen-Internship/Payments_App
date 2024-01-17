using System;
using QArte.API.Queries.FeeQuery;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.FeeHandlers
{
	public class FeeGetByCurrencyHandler : IRequestHandler<FeeGetByCurrencyQuery,List<FeeDTO>>
	{
		private readonly IFeeService _feeService;

		public FeeGetByCurrencyHandler(IFeeService feeService)
		{
			_feeService = feeService; 
		}

        public async Task<List<FeeDTO>> Handle(FeeGetByCurrencyQuery request, CancellationToken cancellationToken)
        {
			var order = await _feeService.GetFeesByCurrency(request.currency);
            return (List<FeeDTO>)order;
        }
    }
}

