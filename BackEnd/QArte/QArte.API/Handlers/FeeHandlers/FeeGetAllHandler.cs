using System;
using QArte.API.Queries.FeeQuery;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.FeeHandlers
{
	public class FeeGetAllHandler : IRequestHandler<FeeGetAllQuery,List<FeeDTO>>
	{
		private readonly IFeeService _feeService;

		public FeeGetAllHandler(IFeeService feeService)
		{
			_feeService = feeService;
		}

        public async Task<List<FeeDTO>> Handle(FeeGetAllQuery request, CancellationToken cancellationToken)
        {
			var order = await _feeService.GetAsync();
			return (List<FeeDTO>)order;
			//fixed
        }
    }
}

