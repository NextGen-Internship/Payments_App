using System;
using QArte.API.Queries.InvoiceQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;
using QArte.Services.Services;

namespace QArte.API.Handlers.InvoiceHandlers
{
    public class InvoiceGetByIDHandler : IRequestHandler<GetInvoiceByIDQuery, InvoiceDTO>
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceGetByIDHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public async Task<InvoiceDTO> Handle(GetInvoiceByIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _invoiceService.GetInvoiceByID(request.invoiceID);
            return order;
        }

    }
}

