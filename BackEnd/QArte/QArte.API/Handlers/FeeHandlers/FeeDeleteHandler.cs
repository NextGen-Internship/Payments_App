using System;
using QArte.API.Commands.FeeCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.FeeHandlers
{
	public class FeeDeleteHandler : IRequestHandler<FeeDeleteCommand,FeeDTO>
	{
        private readonly IFeeService _feeService;

        public FeeDeleteHandler(IFeeService feeService)
        {
            _feeService = feeService;
        }

        public async Task<FeeDTO> Handle(FeeDeleteCommand request, CancellationToken cancellationToken)
        {
            var order = await _feeService.DeleteAsync(request.id);
            return order;
        }
    }
}

