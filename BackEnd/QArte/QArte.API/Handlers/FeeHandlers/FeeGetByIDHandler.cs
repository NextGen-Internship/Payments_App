using System;
using QArte.API.Queries.FeeQuery;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.FeeHandlers
{
	public class FeeGetByIDHandler : IRequestHandler<FeeGetByIDQuery, FeeDTO>
	{
		private readonly IFeeService _feeService;
		public FeeGetByIDHandler(IFeeService feeService)
		{
			this._feeService = feeService;
		}

        public async Task<FeeDTO> Handle(FeeGetByIDQuery request, CancellationToken cancellationToken)
        {
			var order = await _feeService.GetFeeByID(request.id);
			return order;
        }
    }
}

