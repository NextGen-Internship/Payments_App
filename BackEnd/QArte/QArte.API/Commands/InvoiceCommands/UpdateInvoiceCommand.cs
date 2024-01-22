using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Commands.InvoiceCommands
{
    public class UpdateInvoiceCommand : IRequest<InvoiceDTO>
    {

        public int Id;
        public InvoiceDTO invoiceDTO;

        public UpdateInvoiceCommand(int id, InvoiceDTO invoiceDTO)
        {
            this.Id = id;
            this.invoiceDTO = invoiceDTO;
        }
    }
}