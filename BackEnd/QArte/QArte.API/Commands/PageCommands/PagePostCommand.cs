using System;
using MediatR;
using QArte.Services.DTOs;
namespace QArte.API.Commands.PageCommands
{
	public class PagePostCommand : IRequest<PageDTO>
	{
		public PageDTO pageDTO;
		public PagePostCommand(PageDTO pageDTO)
		{
			this.pageDTO = pageDTO;
		}
	}
}

