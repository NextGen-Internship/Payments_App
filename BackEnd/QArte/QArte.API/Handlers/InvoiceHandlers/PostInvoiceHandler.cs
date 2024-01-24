using System;
using QArte.API.Commands.InvoiceCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;
using QArte.Services.Services;

namespace QArte.API.Handlers.InvoiceHandlers
{
    public class PostInvoiceHandler : IRequestHandler<PostInvoiceCommand, InvoiceDTO>
    {
        private readonly IInvoiceService _invoiceService;
        public PostInvoiceHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public Task<InvoiceDTO> Handle(PostInvoiceCommand request, CancellationToken cancellationToken)
        {
            var order = _invoiceService.PostAsync(request.InvoiceDTO);
            return order;
        }
    }
}

