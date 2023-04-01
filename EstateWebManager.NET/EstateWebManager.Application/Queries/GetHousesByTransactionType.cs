using EstateWebManager.Domain.Models.RealEstateClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateWebManager.Application.Queries
{
    public class GetHousesByTransactionType : IRequest<List<House>>
    {
        public string City { get; set; }
        public string TransactionType { get; set; }
    }
}
