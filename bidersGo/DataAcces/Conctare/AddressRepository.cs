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

        public Address GetByCityWithStudent()
        {
            return null;
        }
    }
}
