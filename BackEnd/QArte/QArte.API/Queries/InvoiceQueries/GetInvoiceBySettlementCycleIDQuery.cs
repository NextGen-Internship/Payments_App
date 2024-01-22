using System;
using MediatR;
using QArte.Services.DTOs;

namespace QArte.API.Queries.InvoiceQueries
{
    public class GetInvoiceBySettlementCycleIDQuery : IRequest<InvoiceDTO>
    {
        public int id;

		public GetInvoiceBySettlementCycleIDQuery(int _id)
        {
            id = _id;

        }
    }
}