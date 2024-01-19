using System;
using MediatR;
using QArte.Services.DTOs;

namespace QArte.API.Commands.PageCommands
{
	public class PageDeleteCommand : IRequest<PageDTO>
	{
		public int id;

		public PageDeleteCommand(int id)
		{
			this.id = id;
		}
	}
}

