using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.InvoiceCommands
{
    public class PostInvoiceCommand : IRequest<InvoiceDTO>
    {
        public InvoiceDTO InvoiceDTO;

        public PostInvoiceCommand(InvoiceDTO invoiceDTO)
        {
            InvoiceDTO = invoiceDTO;
        }
    }
}