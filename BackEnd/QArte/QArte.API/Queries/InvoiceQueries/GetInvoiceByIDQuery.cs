using System;
using MediatR;
using QArte.Services.DTOs;

namespace QArte.API.Queries.InvoiceQueries
{
    public class GetInvoiceByIDQuery : IRequest<InvoiceDTO>
    {
        public int invoiceID;
        public GetInvoiceByIDQuery(int _invopiceID)
        {
            invoiceID = _invopiceID;

        }
    }
}
