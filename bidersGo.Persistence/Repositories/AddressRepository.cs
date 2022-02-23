using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Application.Interfaces.Repositories;
using bidersGo.Domain.Entities;
using bidersGo.Persistence.Context;


namespace bidersGo.Persistence.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        private readonly ApplicationDbContext _context;
        public AddressRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        
        Address IAddressRepository.GetAddressById(Guid guid)
        {
            return _context.Addresses.Where(x => x.Id == guid).FirstOrDefault();
        }

        List<Address> IAddressRepository.getAllAdresAddresses()
        {
            return _context.Addresses.ToList();
        }

        Address IAddressRepository.GetByCityWithStudent(string CityName)
        {
            return _context.Addresses.Where(x => x.City == CityName).FirstOrDefault();
        }

        Address IAddressRepository.GetSelectedAdress(Address address)
        {
            return _context.Addresses.Where(x => x.Id == address.Id).FirstOrDefault();
        }
    }
}
