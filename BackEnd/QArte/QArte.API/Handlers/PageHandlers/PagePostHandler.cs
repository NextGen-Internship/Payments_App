using System;
using QArte.API.Commands.PageCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.PageHandlers
{
	public class PagePostHandler : IRequestHandler<PagePostCommand,PageDTO>
	{
        private readonly IPageService _pageService;

        public PagePostHandler(IPageService page)
        {
            _pageService = page;
        }

        public async Task<PageDTO> Handle(PagePostCommand request, CancellationToken cancellationToken)
        {
            var order = await _pageService.PostAsync(request.pageDTO);
            return order;
        }
    }
}

