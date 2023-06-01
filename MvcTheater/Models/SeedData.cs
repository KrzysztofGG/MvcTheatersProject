using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MvcActor.Data;
using MvcTheater.Models;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcActorContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcActorContext>>()))
        {
            // Look for any movies.
            if (context.Actor.Any())
            {
                return;   // DB has been seeded
            }
            context.Actor.AddRange(
                new Actor
                {
                    FirstName = "Tomek",
                    LastName = "Zawadzki",
                    Age = 34,
                    Country = "Poland",
                    FavoriteMovie = "Matrix",

                },
                new Actor
                {
                    FirstName = "Adi",
                    LastName = "Kot",
                    Age = 25,
                    Country = "Poland",
                    FavoriteMovie = "Shrek",

                },
                new Actor
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Age = 56,
                    Country = "USA",
                    FavoriteMovie = "Titanic",

                },
                new Actor
                {
                    FirstName = "Rahim",
                    LastName = "Karabavi",
                    Age = 44,
                    Country = "Turkey",
                    FavoriteMovie = "Rambo",

                }
            );
            context.SaveChanges();
        }
    }
}