
using System;
using MediatR;
using QArte.Services.DTOs;

namespace QArte.API.Queries.InvoiceQueries
{
    public class GetInvoiceByFeeIDQuery : IRequest<InvoiceDTO>
    {
        int feeID;

        public GetInvoiceByFeeIDQuery(int _feeId)
        {
            feeID = _feeId;
        }
    }
}

