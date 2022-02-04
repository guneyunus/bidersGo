using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGo.Entities
{
    public class Address:BaseEntity
    {

        
        public string ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Street { get; set; }

        public string DoorNo { get; set; }

        public AddressTypes AddressType { get; set; }

        public enum AddressTypes
        {
            Fatura,
            Teslimat
        }
    }
}
