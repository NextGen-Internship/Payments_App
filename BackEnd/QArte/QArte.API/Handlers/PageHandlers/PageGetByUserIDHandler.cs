using System;
using QArte.API.Queries.PageQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.PageHandlers
{
	public class PageGetByUserIDHandler : IRequestHandler<PageGetByUserIDQuery,List<PageDTO>>
	{
        private readonly IPageService _pageService;

        public PageGetByUserIDHandler(IPageService page)
        {
            _pageService = page;
        }

        public async Task<List<PageDTO>> Handle(PageGetByUserIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _pageService.GetPagesByUserID(request.id);
            return (List<PageDTO>)order;
        }
    }
}

