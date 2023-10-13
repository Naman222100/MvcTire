using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcTire.Data;
using System;
using System.Linq;

namespace MvcTire.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcTireContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcTireContext>>()))
            {
                if (context.Tire.Any())
                {
                    return;    
                }

                context.Tire.AddRange(
                    new Tire
                    {
                        Brand = "Ceat",
                        Colour= "Black",
                        Price = 3421,
                        Size=24
                    },

                    new Tire
                    {
                        Brand = "Dust",
                        Colour = "Blue",
                        Price = 2341,
                        Size = 25
                    },

                    new Tire
                    {
                        Brand = "Ceat",
                        Colour = "Black",
                        Price = 2111,
                        Size = 22
                    },

                    new Tire
                    {
                        Brand = "Ultra",
                        Colour = "Blue",
                        Price = 3211,
                        Size = 26
                    },
                    new Tire
                    {
                        Brand = "Ceat",
                        Colour = "Blue",
                        Price = 3122,
                        Size = 24
                    },
                    new Tire
                    {
                        Brand = "Ultra",
                        Colour = "Red",
                        Price = 2099,
                        Size = 22
                    }, new Tire
                    {
                        Brand = "SafeDrive",
                        Colour = "Purple",
                        Price = 2312,
                        Size = 21
                    },
                    new Tire
                    {
                        Brand = "Safari",
                        Colour = "Black",
                        Price = 2231,
                        Size = 25
                    },
                    new Tire
                    {
                        Brand = "Climbers",
                        Colour = "Blue",
                        Price = 2260,
                        Size = 23
                    },
                    new Tire
                    {
                        Brand = "Truckers",
                        Colour = "Black",
                        Price = 1200,
                        Size = 23
                    }
                );
                context.SaveChanges();
            }
        }
    }
}