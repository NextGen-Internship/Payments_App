using System;
using QArte.API.Queries.BanTableQuery;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.BanTableHandlers
{
    public class BanTableGetAllHandler : IRequestHandler<BanTableGetAllQuery, List<BanTableDTO>>
	{
        private readonly IBanTableService _banTableService;


        public BanTableGetAllHandler(IBanTableService ban)
		{
            this._banTableService = ban;
		}

        public async Task<List<BanTableDTO>> Handle(BanTableGetAllQuery request, CancellationToken cancellationToken)
        {
            var order = await _banTableService.GetAsync();
            return (List<BanTableDTO>)order;
        }
    }
}

