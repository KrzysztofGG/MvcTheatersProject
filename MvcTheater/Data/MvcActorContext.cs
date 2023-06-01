using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcTheater.Models;

namespace MvcActor.Data
{
    public class MvcActorContext : DbContext
    {
        public MvcActorContext (DbContextOptions<MvcActorContext> options)
            : base(options)
        {
        }

        public DbSet<MvcTheater.Models.Actor> Actor { get; set; } = default!;
        public DbSet<MvcTheater.Models.Team> Team { get; set; } = default!;
        public DbSet<MvcTheater.Models.Show> Show { get; set; } = default!;
        public DbSet<MvcTheater.Models.Opinion> Opinion { get; set; } = default!;
        public DbSet<MvcTheater.Models.User> User { get; set; } = default!;

    }
}
