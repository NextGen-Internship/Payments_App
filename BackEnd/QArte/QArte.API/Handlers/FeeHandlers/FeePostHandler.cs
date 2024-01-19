using System;
using QArte.API.Commands.FeeCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.FeeHandlers
{
	public class FeePostHandler : IRequestHandler<FeePostCommand,FeeDTO>
	{
        private readonly IFeeService _feeService;

        public FeePostHandler(IFeeService fee)
        {
            _feeService = fee;
        }

        public async Task<FeeDTO> Handle(FeePostCommand request, CancellationToken cancellationToken)
        {
            var order = await _feeService.PostAsync(request.feeDTO);
            return order;
        }
    }
}

