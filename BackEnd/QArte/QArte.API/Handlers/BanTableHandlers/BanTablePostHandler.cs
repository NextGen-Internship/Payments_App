using System;
using QArte.API.Commands.BanTableCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.BanTableHandlers
{
    public class BanTablePostHandler : IRequestHandler<BanTablePostCommand, BanTableDTO>
	{

        private readonly IBanTableService _banTableService;

		public BanTablePostHandler(IBanTableService ban)
		{
            _banTableService = ban;
		}

        public async Task<BanTableDTO> Handle(BanTablePostCommand request, CancellationToken cancellationToken)
        {
            var order = await _banTableService.PostAsync(request.banTable);
            return order;
        }
    }
}

