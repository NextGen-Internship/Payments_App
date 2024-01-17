using System;
using QArte.API.Commands.PageCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using MediatR;

namespace QArte.API.Handlers.PageHandlers
{
	public class PageDeleteHandler : IRequestHandler<PageDeleteCommand,PageDTO>
	{
        private readonly IPageService _pageService;

		public PageDeleteHandler(IPageService page)
		{
            _pageService = page;
		}

        public async Task<PageDTO> Handle(PageDeleteCommand request, CancellationToken cancellationToken)
        {
            var order = await _pageService.DeleteAsync(request.id);
            return order;
        }
    }
}

