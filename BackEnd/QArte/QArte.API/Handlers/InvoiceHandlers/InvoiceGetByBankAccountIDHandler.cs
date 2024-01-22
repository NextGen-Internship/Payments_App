using System;
using QArte.API.Queries.InvoiceQueries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Handlers.InvoiceHandlers
{
    public class InvoiceGetByBankAccountIDHandler : IRequestHandler<GetInvoiceBankAccountByIDQuery, InvoiceDTO>
    {
        private readonly IInvoiceService invoiceService;

        public InvoiceGetByBankAccountIDHandler(IInvoiceService _invoiceService)
        {
            invoiceService = _invoiceService;
        }

        public async Task<InvoiceDTO> Handle(GetInvoiceBankAccountByIDQuery request, CancellationToken cancellationToken)
        {
            var order = await invoiceService.GetInvoiceByBankAccountID(request.bankAccountID);
            return order;
        }
    }
}


