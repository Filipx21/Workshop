using CarWorkshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private CarWorkshopDbContext dbContext;

        public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.CarWorkshops.Any())
                {
                    var workshop = new Domain.Entities.CarWorkshop()
                    {
                        Name = "Mazda ASO",
                        Description = "Autoryzowany serwis Mazda",
                        ContactDetails = new()
                        {
                            City = "Kraków",
                            Street = "Szewska 2",
                            PostalCode = "30-001",
                            PhoneNumber = "+48773669122"
                        }
                    };
                    workshop.EncodeName();
                    await dbContext.CarWorkshops.AddAsync(workshop);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
