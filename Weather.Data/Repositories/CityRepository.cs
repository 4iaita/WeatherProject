using System;
using System.Collections.Generic;
using System.Text;
using Weather.Data.EF;
using Weather.Data.Entities;
using Weather.Data.Interfaces;

namespace Weather.Data.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(DatabaseContext context) : base(context)
        {
        }


    }
}
