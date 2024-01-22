using System;
using QArte.API.Queries.InvoiceQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;
using QArte.API.Queries.BankAccountQueries;

namespace QArte.API.Handlers.InvoiceHandlers
{
    public class InvoiceGetBySettlementCycleIDHandler : IRequestHandler<GetInvoiceBySettlementCycleIDQuery, InvoiceDTO>
    {
        private readonly IInvoiceService _invoiceService;


        public InvoiceGetBySettlementCycleIDHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public async Task<InvoiceDTO> Handle(GetInvoiceBySettlementCycleIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _invoiceService.GetInvoiceBySettlementCycleID(request.id);
            return order;
        }
    }
}

