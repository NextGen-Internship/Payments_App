using System;
using QArte.API.Commands.FeeCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.FeeHandlers
{
	public class FeePatchHandler : IRequestHandler<FeePatchCommand,FeeDTO>
	{
        private readonly IFeeService _feeService;

		public FeePatchHandler(IFeeService fee)
		{
            _feeService = fee;
		}

        public async Task<FeeDTO> Handle(FeePatchCommand request, CancellationToken cancellationToken)
        {
            var order = await _feeService.UpdateAsync(request.id, request.feeDTO);
            return order;
        }
    }
}

