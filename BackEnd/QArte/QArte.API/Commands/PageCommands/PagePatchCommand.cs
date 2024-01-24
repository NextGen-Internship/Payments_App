using System;
using MediatR;
using QArte.Services.DTOs;
namespace QArte.API.Commands.PageCommands
{
	public class PagePatchCommand : IRequest<PageDTO>
	{
		public int id;
		public PageDTO PageDTO;
		public PagePatchCommand(int id, PageDTO pageDTO)
		{
			this.id = id;
			this.PageDTO = pageDTO;
		}
	}
}

