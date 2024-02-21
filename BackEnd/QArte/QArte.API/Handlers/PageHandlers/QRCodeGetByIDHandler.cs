using System;
using QArte.API.Queries.PageQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.PageHandlers
{
	public class QRCodeGetByIDHandler:IRequestHandler<QRCodeGetByID,PageDTO>
	{
        private readonly IPageService _pageService;

		public QRCodeGetByIDHandler(IPageService pageService)
		{
            _pageService = pageService;
        }


        public async Task<PageDTO> Handle(QRCodeGetByID request, CancellationToken cancellationToken)
        {
            var order = await _pageService.GetQRCode(request.id);
            return order;
        }
    }
}

