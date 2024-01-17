using System;
using QArte.API.Commands.BanTableCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.BanTableHandlers
{
	public class BanTablePatchHandler : IRequestHandler<BanTablePatchCommand,BanTableDTO>
	{
        private readonly IBanTableService _banTableService;
		public BanTablePatchHandler(IBanTableService banTableService)
		{
            _banTableService = banTableService;
		}

        public async Task<BanTableDTO> Handle(BanTablePatchCommand request, CancellationToken cancellationToken)
        {
            var order = await _banTableService.UpdateAsync(request.id, request.BankAccountDTO);
            return order;
        }
    }
}

