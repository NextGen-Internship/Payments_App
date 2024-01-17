using System;
using QArte.API.Commands.BanTableCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.BanTableHandlers
{
	public class BanTableDeleteHandler : IRequestHandler<BanTableDeleteCommand, BanTableDTO>
	{
		private readonly IBanTableService _banTableService;

		public BanTableDeleteHandler(IBanTableService banTableService)
		{
			_banTableService = banTableService;
		}

        public async Task<BanTableDTO> Handle(BanTableDeleteCommand request, CancellationToken cancellationToken)
        {
			var order = await _banTableService.DeleteAsync(request.id);
			return order;
        }
    }
}

