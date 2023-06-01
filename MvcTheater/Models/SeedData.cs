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
                    FavouriteMovie = "Matrix",

                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}