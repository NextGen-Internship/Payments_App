using System;
using MediatR;
using QArte.Services.DTOs;

namespace QArte.API.Queries.PageQueries
{
	public class QRCodeGetByID:IRequest<PageDTO>
	{
		public int id;
		public QRCodeGetByID(int id)
		{
			this.id = id;
		}
	}
}

