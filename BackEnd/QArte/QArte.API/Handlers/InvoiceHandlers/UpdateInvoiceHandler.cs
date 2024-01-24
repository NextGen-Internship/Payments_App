using System;
using QArte.API.Commands.InvoiceCommands;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.InvoiceHandlers
{
    public class UpdateInvoiceHandler : IRequestHandler<UpdateInvoiceCommand, InvoiceDTO>
    {
        private readonly IInvoiceService invoiceService;

        public UpdateInvoiceHandler(IInvoiceService _invoiceService)
        {
            invoiceService = _invoiceService;
        }

        public async Task<InvoiceDTO> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var order = await invoiceService.UpdateAsync(request.Id, request.invoiceDTO);
            return order;
        }
    }
}

