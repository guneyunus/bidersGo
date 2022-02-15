using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Domain.Entities;

namespace bidersGo.Application.Interfaces.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
        Address GetByCityWithStudent(string CityName);
        Address GetSelectedAdress(Address address);
    }
}
