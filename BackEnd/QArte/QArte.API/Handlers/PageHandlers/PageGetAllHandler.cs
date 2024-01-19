using System;
using QArte.API.Queries.PageQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.PageHandlers
{
	public class PageGetAllHandler : IRequestHandler<PageGetAllQuery,List<PageDTO>>
	{
        private readonly IPageService _pageService;

        public PageGetAllHandler(IPageService page)
        {
            _pageService = page;
        }

        public async Task<List<PageDTO>> Handle(PageGetAllQuery request, CancellationToken cancellationToken)
        {
            var order = await _pageService.GetAsync();
            return (List<PageDTO>)order;
        }
    }
}

