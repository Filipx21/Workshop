using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class CarWorkshopRepository : ICarWorkshopRepository
    {
        private readonly CarWorkshopDbContext dbContext;

        public CarWorkshopRepository(CarWorkshopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            dbContext.Add(carWorkshop);
            await dbContext.SaveChangesAsync();
        }
    }
}
