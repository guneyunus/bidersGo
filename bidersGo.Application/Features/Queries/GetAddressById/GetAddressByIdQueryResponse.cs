using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidersGo.Application.Features.Queries.GetAddressById
{
    public class GetAddressByIdQueryResponse
    {
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string BuildName { get; set; }
        public string Street { get; set; }
        public string BuildNo { get; set; }
    }
}
