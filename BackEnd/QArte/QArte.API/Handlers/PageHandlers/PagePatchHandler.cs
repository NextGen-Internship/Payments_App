using System;
using QArte.API.Commands.PageCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.PageHandlers
{
	public class PagePatchHandler : IRequestHandler<PagePatchCommand,PageDTO>
	{
        private readonly IPageService _pageService;

        public PagePatchHandler(IPageService page)
        {
            _pageService = page;
        }

        public async Task<PageDTO> Handle(PagePatchCommand request, CancellationToken cancellationToken)
        {
            var order = await _pageService.UpdateAsync(request.id,request.PageDTO);
            return order;
        }
    }
}

