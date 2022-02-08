using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.Entities;

namespace bidersGo.DataAcces.Abstract
{
    public interface IAddressRepository : IRepository<Address>
    {
        Address GetByCityWithStudent(string CityName);
    }
}
