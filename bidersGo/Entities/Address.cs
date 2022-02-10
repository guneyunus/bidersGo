using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace bidersGo.Entities
{
    public class Address:BaseEntity
    {

        
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string BuildName { get; set; }
        public string Street { get; set; }
        public string BuildNo { get; set; }

        public AddressTypes AddressType { get; set; }

        public enum AddressTypes
        {
            Fatura,
            DersYeri
        }
    }
}
