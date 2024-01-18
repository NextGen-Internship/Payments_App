using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Queries.UserQueries
{
    public class GetUserNameByIDQuery : IRequest<string>
    {
        public int Id;
        public GetUserNameByIDQuery(int id)
        {
            Id = id;
        }
    }
}

