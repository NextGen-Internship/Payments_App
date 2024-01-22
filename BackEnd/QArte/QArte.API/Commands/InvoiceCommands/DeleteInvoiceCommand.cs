using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.InvoiceCommands
{
    public class DeleteInvoiceCommand : IRequest<InvoiceDTO>
    {
        public int Id;

        public DeleteInvoiceCommand(int id)
        {
            Id = id;
        }
    }
}