using System;
using QArte.API.Queries.PageQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.PageHandlers
{
	public class PageGetByIDHandler : IRequestHandler<PageGetByIDQuery,PageDTO>
	{
        private readonly IPageService _pageService;

        public PageGetByIDHandler(IPageService page)
        {
            _pageService = page;
        }

        public async Task<PageDTO> Handle(PageGetByIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _pageService.GetPageByID(request.id);
            return order;
        }
    }
}

