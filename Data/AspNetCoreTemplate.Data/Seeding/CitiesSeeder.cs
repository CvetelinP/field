using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTemplate.Data.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace AspNetCoreTemplate.Data.Seeding
{
    public class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cities.Any())
            {
                return;

            }

            var cities = new List<string> { "Sofia", "Plovdiv", "Varna", "Burgas", "Stara Zagora", "Veliko Tarnovo", "Pleven", "Ruse" };
            foreach (var city in cities)
            {
                await dbContext.Cities.AddAsync(new City
                {
                    Name = city,
                });
            }
        }
    }
}
 