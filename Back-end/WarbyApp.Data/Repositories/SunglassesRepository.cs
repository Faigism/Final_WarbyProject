using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Core.Entities;
using WarbyApp.Core.Repositories;

namespace WarbyApp.Data.Repositories
{
    public class SunglassesRepository:Repository<Sunglasses>, ISunglassesRepository
    {
        public SunglassesRepository(WarbyAppDbContext context):base(context) { }
    }
}
