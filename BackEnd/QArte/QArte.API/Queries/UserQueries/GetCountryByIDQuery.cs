using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Queries.UserQueries
{
    public class GetCountryByIDQuery : IRequest<string>
    {
        public int Id;
        public GetCountryByIDQuery(int id)
        {
            Id = id;
        }
    }
}

