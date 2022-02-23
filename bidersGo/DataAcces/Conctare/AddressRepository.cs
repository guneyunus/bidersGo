using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.DataAcces.Abstract;
using bidersGo.Entities;

namespace bidersGo.DataAcces.Conctare
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        private readonly BidersGoContext _context;
        public AddressRepository(BidersGoContext context):base(context)
        {
            _context = context;
        }

        public Address GetByCityWithStudent(string CityName)
        {
            return _context.Addresses.Where(x => x.City == CityName).FirstOrDefault();
        }

        public Address GetSelectedAdress(Address address)
        {
            return _context.Addresses.Where(x => x.Id == address.Id).FirstOrDefault();
        }
    }
}
