using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace bidersGo.DataAcces.Conctare
{
    public class BidersGoContext :DbContext
    {
        public BidersGoContext(DbContextOptions options):base(options)
        {
            
        }

    }
}
