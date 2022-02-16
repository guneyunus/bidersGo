using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidersGo.Domain.Entities;
using MediatR;

namespace bidersGo.Application.Features.Commands.AddressCreate
{
    public class AddressCreateCommandRequest :IRequest<AddressCreateCommandResponse>
    {
        
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string BuildName { get; set; }
        public string Street { get; set; }
        public string BuildNo { get; set; }

        public Address.AddressTypes AddressType { get; set; } = Address.AddressTypes.DersYeri;
    }
}
