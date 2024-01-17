using System;
using QArte.API.Queries.BanTableQuery;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.BanTableHandlers
{
	public class BanTableGetByIDHandler : IRequestHandler<BanTableGetByIDQuery,BanTableDTO>
	{
        private readonly IBanTableService _banTableService;
		public BanTableGetByIDHandler(IBanTableService ban)
		{
            _banTableService = ban;
		}

        public async Task<BanTableDTO> Handle(BanTableGetByIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _banTableService.GetBanTableByID(request.id);
            return order;
        }
    }
}

