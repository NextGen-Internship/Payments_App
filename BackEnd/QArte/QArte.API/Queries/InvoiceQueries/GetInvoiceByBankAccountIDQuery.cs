using System;
using QArte.API.Queries;
using QArte.Services.DTOs;
using QArte.Services.ServiceInterfaces;
using QArte.Services.DTOMappers;
using MediatR;

namespace QArte.API.Queries.InvoiceQueries
{
    public class GetInvoiceBankAccountByIDQuery : IRequest<InvoiceDTO>
    {
        public int bankAccountID;

        public GetInvoiceBankAccountByIDQuery(int _bankAccountID)
        {
            bankAccountID = _bankAccountID;
        }


    }
}

