using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Queries.PictureQueries
{
    public class GetPictureAllQuery : IRequest<List<PictureDTO>>
    {
        public GetPictureAllQuery()
        {
        }
    }
}

