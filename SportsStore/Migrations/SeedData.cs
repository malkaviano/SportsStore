using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SportsStore.Migrations
{
    public static class SeedData
    {
        public static void EnsurePopulated(ApplicationDbContext context)
        {
            context.Database.Migrate();

            if (!context.Products.Any())
            {
                context.Products.AddRangeAsync(GetFixture());

                context.SaveChanges();

                Product[] GetFixture()
                {
                    return new Product[]
                    {
                        new Product
                       {
                           Name = "Kayak",
                           Description = "A boat for one person",
                           Category = "Watersports",
                           Price = 275
                       },
                        new Product
                       {
                           Name = "LifeJacket",
                           Description = "Protective and Fashionable",
                           Category = "Watersports",
                           Price = 48.95m
                       },
                        new Product
                        {
                            Name = "Soccer Ball",
                            Description = "FIFA-approved size and weight",
                            Category = "Soccer",
                            Price = 19.50m
                        },
                        new Product
                        {
                            Name = "Corner Flags",
                            Description = "Give your playing field a professional touch",
                            Category = "Soccer",
                            Price = 34.95m
                        },
                        new Product
                        {
                            Name = "Stadium",
                            Description = "Flat-packed 35,000-seat stadium",
                            Category = "Soccer",
                            Price = 79500
                        },
                        new Product
                        {
                            Name = "Thinking Cap",
                            Description = "Improve brain efficiency by 75%",
                            Category = "Chess",
                            Price = 16
                        },
                        new Product
                        {
                            Name = "Unsteady Chair",
                            Description = "Secreatly give your opponent a disavantage",
                            Category = "Chess",
                            Price = 29.95m
                        },
                        new Product
                        {
                            Name = "Human Chess Board",
                            Description = "A fun game for the family",
                            Category = "Chess",
                            Price = 75
                        },
                        new Product
                        {
                            Name = "Bling-Bling King",
                            Description = "Gold-plated, diamond-studded King",
                            Category = "Chess",
                            Price = 1200
                        }
                    };
                }
            }
        }
    }
}
