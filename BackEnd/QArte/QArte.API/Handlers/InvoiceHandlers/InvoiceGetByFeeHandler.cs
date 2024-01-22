using System;
using QArte.API.Queries.InvoiceQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.InvoiceHandlers
{
    public class InvoiceGetByFeeHandler : IRequestHandler<GetInvoiceAllQuery, List<InvoiceDTO>>
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceGetByFeeHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public async Task<List<InvoiceDTO>> Handle(GetInvoiceAllQuery request, CancellationToken cancellationToken)
        {
            var order = await _invoiceService.GetAsync();
            return (List<InvoiceDTO>)order;
        }
    }
}

