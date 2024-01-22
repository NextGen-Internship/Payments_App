using System;
using MediatR;
using QArte.API.Commands.InvoiceCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;

namespace QArte.API.Handlers.InvoiceHandlers
{
    public class DeleteInvoiceHandler : IRequestHandler<DeleteInvoiceCommand, InvoiceDTO>
    {
        private readonly IInvoiceService invoiceService;

        public DeleteInvoiceHandler(IInvoiceService _invoiceService)
        {
            invoiceService = _invoiceService;
        }

        public async Task<InvoiceDTO> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var order = await invoiceService.DeleteAsync(request.Id);
            return order;
        }
    }
}

